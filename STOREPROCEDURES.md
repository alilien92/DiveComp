# DiveComp
//Get Leaderboard by Contest ID
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetLeaderboardByContest`(id int)
    READS SQL DATA
BEGIN

    select divers.`FirstName`, divers.`LastName`, divers.`Club`, participants.`Score`, `participants`.`hasJumped`, `participants`.`DiverId`
    from participants INNER JOIN divers ON participants.diverId = divers.Id
    where participants.`ContestId` = id
    order by Score desc;
END


//Get Dives by Height
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDifficultyMod`(H float )
    READS SQL DATA
BEGIN
    
    select *
    from `difficultymods`
    where H = Height;
END


//Update Score by Diver Id & new score
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateScore`(contestid int, diverid int, newscore float)
BEGIN
    Update `participants`
    set Score = (Score + newscore), `participants`.`hasJumped` = `participants`.`hasJumped` + 1
    where `participants`.`DiverId` = diverid and `participants`.`ContestId` = contestid;
END






//Get all event types
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllEventTypes`()
    READS SQL DATA
BEGIN
    
    select *
    from `eventtypes`;
    
END




//Get EventType
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEventType`(Typeid int)
BEGIN
    select * from `eventtypes`
    where Id = Typeid;
END




//Get Judges by ContestID
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetJudgeByContestId`(cid int)
BEGIN
    SELECT judges.*
FROM judges INNER JOIN judgeparticipant 
ON judges.Id = judgeparticipant.JudgeId
where `judgeparticipant`.`ContestId` = cid;
END



//Get Divers by Contest ID
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDiverListByContest`(id int)
BEGIN
    select * from `divers`
    inner join `participants` on `participants`.`DiverId` = `divers`.`Id`
    where `participants`.`ContestId` = id;
END

//Get STR Diff mod by height and divecodenumber
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDiffModSTR`(H float, dcn int)
BEGIN


    select `difficultymods`.`STR` from `difficultymods` 
    where `difficultymods`.`DiveCodeNumber` = dcn and `difficultymods`.`Height` = H;
END







//Get Pike Diff mod by height and divecodenumber
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDiffModPike`(H float, dcn int)
BEGIN


    select `difficultymods`.`Pike` from `difficultymods` 
    where `difficultymods`.`DiveCodeNumber` = dcn and `difficultymods`.`Height` = H;


END

//Get Tuck Diff mod by height and divecodenumber
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDiffModTuck`(H float, dcn int)
BEGIN


    select `difficultymods`.`Tuck` from `difficultymods` 
    where `difficultymods`.`DiveCodeNumber` = dcn and `difficultymods`.`Height` = H;


END


//Get Free Diff mod by height and divecodenumber
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDiffModFree`(H float, dcn int)
BEGIN


    select `difficultymods`.`STR` from `difficultymods` 
    where `difficultymods`.`DiveCodeNumber` = dcn and `difficultymods`.`Height` = H;
END

//Get divers not in contest
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDiversNotInContest`(id int)
BEGIN
    SELECT * 
    FROM `divers`
    WHERE `divers`.`Id` NOT IN 
        (SELECT `participants`.`diverId` 
         FROM `participants` 
         WHERE `participants`.`contestId` = id);
END






//Get judges not in contest

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetJudgesNotInContest`(id int)
BEGIN
    SELECT * 
    FROM `judges`
    WHERE `judges`.`Id` NOT IN 
        (SELECT `judgeParticipant`.`judgeId` 
         FROM `judgeParticipant` 
         WHERE `judgeParticipant`.`contestId` = id);
END
