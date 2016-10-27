--find some text in a sproc
SELECT DISTINCT
       o.name AS Object_Name,
       o.type_desc
  FROM sys.sql_modules m
       INNER JOIN
       sys.objects o
         ON m.object_id = o.object_id
 WHERE m.definition Like '%[ABD]%';

 
 
 /***********************************************************************************************
** Logical Advantage, LLC
** www.logicaladvantage.com
** 704-377-5066
** -----------------------------------------------------------------------------------------------------------------------------
** Stored Procedure: prcIssuesRetrieveListForWorkOrder
** 
** Description:	
**
** Version:	1.0.0
**	
** Author:	
** 
** -----------------------------------------------------------------------------------------------------------------------------
** Change Log:
** v1.0.0	08/30/2016	Manny added strSurveyName for DG-530 Manage Alerts Page - Missing key data in the display for each
***********************************************************************************************/