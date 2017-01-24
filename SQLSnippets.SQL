--find some text in a sproc
SELECT DISTINCT
       o.name AS Object_Name,
       o.type_desc
  FROM sys.sql_modules m
       INNER JOIN
       sys.objects o
         ON m.object_id = o.object_id
 WHERE m.definition Like '%[ABD]%';

 
 --Search Tables:
SELECT c.name AS ColName, t.name AS TableName
FROM sys.columns c
    JOIN sys.tables t ON c.object_id = t.object_id
WHERE c.name LIKE '%MyName%'

--Search Tables & Views:
SELECT COLUMN_NAME, TABLE_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE COLUMN_NAME LIKE '%MyName%'
 
 
--does colum exist in table
IF EXISTS(SELECT * FROM  INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'ttblClientContacts' AND COLUMN_NAME = 'strSecondaryEmailAddress') 
BEGIN
	ALTER TABLE ttblClientContacts DROP strSecondaryEmailAddress;
END	
 
/***********************************************************************************************
** Logical Advantage, LLC
** www.logicaladvantage.com
** 704-377-5066
** -----------------------------------------------------------------------------------------------------------------------------
** Stored Procedure: prcParticipantsForSurveyRetrieve
** 
** Description:	get participants for some survey
**
** Loading tests: 
**      prcParticipantsForSurveyRetrieve 200361
**
** See results:
**
** Version:	1.0.1
**	
** Author:	Manny
** 
** -----------------------------------------------------------------------------------------------------------------------------
** Change Log:
** v1.0.0	10/20/2016	Manny Created
** v1.0.1	11/14/2016	Manny - Added Secondary Phone Number
***********************************************************************************************/


--cte
WITH RecursiveCount_CTE(Number)
AS
(
    SELECT 0 AS Number
    UNION ALL
    SELECT Number + 1
    FROM RecursiveCount_CTE
    WHERE Number < 50
)
select * from RecursiveCount_CTE