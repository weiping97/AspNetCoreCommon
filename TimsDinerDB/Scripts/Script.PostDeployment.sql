/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF not exists (SELECT * FROM dbo.Food)
BEGIN
    INSERT INTO dbo.Food(Title, [Description], Price)
    VALUES ('Cheeseburger Meal', 'Cheeseburger, fries, and a drink', 5.95),
    ('Chili Dog Meal', 'Two chili dogs, fries, and a drink', 4.15),
    ('Vegan Meal', 'A large salad and a water', 1.95);
END