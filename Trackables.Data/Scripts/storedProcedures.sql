USE [MyFoodDiary]
GO
/****** Object:  StoredProcedure [dbo].[DeleteFavourite]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Auhor:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteFavourite](@userId int, @code varchar(100))	
AS

DELETE FROM
	Favourites
WHERE 
	UserId = @userId
AND
	Code = @code


GO
/****** Object:  StoredProcedure [dbo].[DeleteFoodItem]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteFoodItem](@Id int)	
AS

DELETE FROM
	FoodItems
WHERE 
	Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[DeleteIngredient]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteIngredient](@Id int)	
AS

DELETE FROM
	Ingredients
WHERE 
	Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[DeleteMeal]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMeal](@Id int)	
AS

DELETE FROM
	Meals
WHERE 
	Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProduct](@Code varchar(255))	
AS
	
UPDATE
	Labelling
SET
	[IsDeleted] = 1
WHERE 
	[Food Code] = @Code



GO
/****** Object:  StoredProcedure [dbo].[DeleteTrackable]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTrackable](@Id int)	
AS

DELETE FROM
	Trackables
WHERE 
	Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllProducts](@userId nvarchar(128))
AS

SELECT 
	labels.[Food Code] AS Code, 
	labels.[Food Name] AS Name, 
	proximates.[Protein (g)] AS Protein,
	proximates.[Fat (g)] AS Fat,
	proximates.[Carbohydrate (g)] AS Carbohydrates,
	proximates.[Energy (kcal) (kcal)] AS Calories,
	proximates.[Alcohol (g)] AS Alcohol,	
	proximates.[Total sugars (g)] AS [Total Sugars],
	proximates.[NSP (g)] AS Fibre,
	proximates.[Cholesterol (mg)] AS Cholesterol,	
  	inorganics.[Sodium (mg)] AS Sodium,
   	inorganics.[Potassium (mg)] AS Potassium,
   	inorganics.[Calcium (mg)] AS Calcium,
   	inorganics.[Magnesium (mg)] AS Magnesium,
   	inorganics.[Iron (mg)] AS Iron,
   	inorganics.[Copper (mg)] AS Copper,
   	inorganics.[Zinc (mg)] AS Zinc,
	inorganics.[Manganese (mg)] AS Manganese,
	inorganics.[Phosphorus (mg)] AS Phosphorus,
	inorganics.[Selenium (µg)] AS Selenium,
	vitamins.[Vitamin D (µg)] AS [Vitamin D],
	vitamins.[Vitamin C (mg)] AS [Vitamin C],	
	vitamins.[Vitamin E (mg)] AS [Vitamin E],	
	vitamins.[Vitamin K1 (µg)] AS [Vitamin K1],	
	vitamins.[Vitamin B6 (mg)] AS [Vitamin B6],	
	vitamins.[Vitamin B12 (µg)] AS [Vitamin B12], 
	vitamins.[Retinol Equivalent (µg)] AS [Vitamin A],
	vitamins.[Carotene (µg)] AS [Carotene],
	vitamins.[Pantothenate (mg)] AS [Pantothenic acid],
	vitamins.[Thiamin (mg)] AS [Thiamin],
	vitamins.[Riboflavin (mg)] AS [Riboflavin],
	vitamins.[Niacin (mg)] AS [Niacin],
	vitamins.[Folate (µg)] AS [Folate]
FROM 
	[MyFoodDiary].[dbo].[Proximates] AS proximates
INNER JOIN
	[MyFoodDiary].[dbo].[Labelling] AS labels
ON
	labels.[Food Code] = proximates.[Food Code] AND (labels.UserId = @userId OR labels.UserId IS NULL)
INNER JOIN
	[MyFoodDiary].[dbo].[Inorganics] AS inorganics
ON
	proximates.[Food Code] = inorganics.[Food Code] AND (inorganics.UserId = @userId OR inorganics.UserId IS NULL)
INNER JOIN
	[MyFoodDiary].[dbo].[Vitamins] AS vitamins
ON
	proximates.[Food Code] = vitamins.[Food Code] AND (vitamins.UserId = @userId OR vitamins.UserId IS NULL)
WHERE
	proximates.[Group] != 'CUSTOM' OR (proximates.[Group] = 'CUSTOM' AND proximates.[UserId] = @userId)
AND 
	labels.IsDeleted = 0



GO
/****** Object:  StoredProcedure [dbo].[GetCustomProductCount]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomProductCount](@UserId nvarchar(128))	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		COUNT(*) AS ProductCount
	FROM 
		[MyFoodDiary].[dbo].[Proximates]
	WHERE 
		UserId = @UserId	
END



GO
/****** Object:  StoredProcedure [dbo].[GetCustomProducts]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomProducts](@userId nvarchar(128))	
AS

SELECT 
	proximates.[Food Code] AS Code, 
	proximates.[Food Name] AS Name, 
	proximates.[Protein (g)] AS Protein,
	proximates.[Fat (g)] AS Fat,
	proximates.[Carbohydrate (g)] AS Carbohydrates,
	proximates.[Energy (kcal) (kcal)] AS Calories,
	proximates.[Alcohol (g)] AS Alcohol,	
	proximates.[Total sugars (g)] AS [Total Sugars],
	proximates.[NSP (g)] AS [Fibre],
	proximates.[Cholesterol (mg)] AS Cholesterol,
  	inorganics.[Sodium (mg)] AS Sodium,
   	inorganics.[Potassium (mg)] AS Potassium,
   	inorganics.[Calcium (mg)] AS Calcium,
   	inorganics.[Magnesium (mg)] AS Magnesium,
   	inorganics.[Iron (mg)] AS Iron,
   	inorganics.[Copper (mg)] AS Copper,
   	inorganics.[Zinc (mg)] AS Zinc,
	inorganics.[Manganese (mg)] AS Manganese,
	inorganics.[Phosphorus (mg)] AS Phosphorus,
	inorganics.[Selenium (µg)] AS Selenium,
	vitamins.[Vitamin D (µg)] AS [Vitamin D],
	vitamins.[Vitamin C (mg)] AS [Vitamin C],	
	vitamins.[Vitamin E (mg)] AS [Vitamin E],	
	vitamins.[Vitamin K1 (µg)] AS [Vitamin K1],	
	vitamins.[Vitamin B6 (mg)] AS [Vitamin B6],	
	vitamins.[Vitamin B12 (µg)] AS [Vitamin B12], 
	vitamins.[Retinol Equivalent (µg)] AS [Vitamin A],
	vitamins.[Carotene (µg)] AS [Carotene],
	vitamins.[Pantothenate (mg)] AS [Pantothenic acid],
	vitamins.[Thiamin (mg)] AS [Thiamin],
	vitamins.[Riboflavin (mg)] AS [Riboflavin],
	vitamins.[Niacin (mg)] AS [Niacin],
	vitamins.[Folate (µg)] AS [Folate]
FROM 
	[MyFoodDiary].[dbo].[Proximates] AS proximates
INNER JOIN
	[MyFoodDiary].[dbo].[Labelling] AS labelling
ON
	proximates.[Food Code] = labelling.[Food Code] AND labelling.UserId = @userId
INNER JOIN
	[MyFoodDiary].[dbo].[Inorganics] AS inorganics
ON
	proximates.[Food Code] = inorganics.[Food Code] AND inorganics.UserId = @userId
INNER JOIN
	[MyFoodDiary].[dbo].[Vitamins] AS vitamins
ON
	proximates.[Food Code] = vitamins.[Food Code] AND vitamins.UserId = @userId
WHERE 
	proximates.[Group] = 'CUSTOM'
AND
	proximates.[UserId] = @userId
AND 
	labelling.IsDeleted = 0





GO
/****** Object:  StoredProcedure [dbo].[GetFavourites]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFavourites](@userId int)	
AS

SELECT 
	f.Code, f.Quantity, l.[Food Name] AS Name
FROM 
	Favourites  f
INNER JOIN
	MyFoodDiary.dbo.Labelling l 
ON
	f.Code = l.[Food Code] Collate SQL_Latin1_General_CP1_CI_AS
WHERE
	f.UserId = @userId


GO
/****** Object:  StoredProcedure [dbo].[GetFoodItem]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFoodItem](@Code nvarchar(255))	
AS

SELECT 
	f.Id, f.Code, l.[Food Name] AS Name, f.Quantity, f.Date
FROM 
	FoodItems f
INNER JOIN
	MyFoodDiary.dbo.Labelling l
ON
	f.Code = l.[Food Code] Collate SQL_Latin1_General_CP1_CI_AS
WHERE
	f.Code = @Code
AND 
	l.IsDeleted = 0


GO
/****** Object:  StoredProcedure [dbo].[GetFoodItems]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFoodItems](@dt datetime, @userId nvarchar(128))	
AS

SELECT 
	f.Id, f.Code, l.[Food Name] AS Name, f.Quantity, f.Date, f.UserId
FROM 
	FoodItems f
INNER JOIN
	MyFoodDiary.dbo.Labelling l
ON
	f.Code = l.[Food Code] Collate SQL_Latin1_General_CP1_CI_AS
WHERE
	f.[Date] = @dt
AND 
	f.UserId = @userId
AND 
	l.IsDeleted = 0
AND 
	(l.UserId = @userId OR l.UserId IS NULL)




GO
/****** Object:  StoredProcedure [dbo].[GetIngredients]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetIngredients](@userId nvarchar(128),@mealId int)	
AS

SELECT 
	i.Id, i.Code, i.MealId, i.Quantity, l.[Food Name] AS Name
FROM 
	Ingredients i
INNER JOIN
	MyFoodDiary.dbo.Labelling l
ON
	i.Code = l.[Food Code] Collate SQL_Latin1_General_CP1_CI_AS
WHERE
	i.MealId = @mealId
AND 
	l.IsDeleted = 0
AND
(
	(l.[Group] = 'CUSTOM' AND l.UserId = @userId) 
	OR 
	(l.[Group] != 'CUSTOM')
)

GO
/****** Object:  StoredProcedure [dbo].[GetMeal]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMeal](@id int)	
AS

SELECT 
	m.Id, m.Name
FROM 
	Meals m
WHERE
	m.Id = @id



GO
/****** Object:  StoredProcedure [dbo].[GetMeals]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMeals](@userId nvarchar(128))	
AS

SELECT 
	m.Id AS Id,
	m.Name AS Name
FROM 
	Meals m
WHERE
	m.UserId = @userId



GO
/****** Object:  StoredProcedure [dbo].[GetProduct]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProduct](@userId nvarchar(128), @Code varchar(255))	
AS
	
SELECT 
	proximates.[Food Code] AS Code, 
	proximates.[Food Name] AS Name, 
	proximates.[Protein (g)] AS Protein,
	proximates.[Fat (g)] AS Fat,
	proximates.[Carbohydrate (g)] AS Carbohydrates,
	proximates.[Energy (kcal) (kcal)] AS Calories,
	proximates.[Alcohol (g)] AS Alcohol,
	proximates.[Total sugars (g)] AS [Total Sugars],
	proximates.[NSP (g)] AS [Fibre],
	proximates.[Cholesterol (mg)] AS Cholesterol,
  	inorganics.[Sodium (mg)] AS Sodium,
   	inorganics.[Potassium (mg)] AS Potassium,
   	inorganics.[Calcium (mg)] AS Calcium,
   	inorganics.[Magnesium (mg)] AS Magnesium,
   	inorganics.[Iron (mg)] AS Iron,
   	inorganics.[Copper (mg)] AS Copper,
   	inorganics.[Zinc (mg)] AS Zinc,
	inorganics.[Manganese (mg)] AS Manganese,
	inorganics.[Phosphorus (mg)] AS Phosphorus,
	inorganics.[Selenium (µg)] AS Selenium,
	vitamins.[Vitamin D (µg)] AS [Vitamin D],
	vitamins.[Vitamin C (mg)] AS [Vitamin C],	
	vitamins.[Vitamin E (mg)] AS [Vitamin E],	
	vitamins.[Vitamin K1 (µg)] AS [Vitamin K1],	
	vitamins.[Vitamin B6 (mg)] AS [Vitamin B6],	
	vitamins.[Vitamin B12 (µg)] AS [Vitamin B12], 
	vitamins.[Retinol Equivalent (µg)] AS [Vitamin A],
	vitamins.[Carotene (µg)] AS [Carotene],
	vitamins.[Pantothenate (mg)] AS [Pantothenic acid],
	vitamins.[Thiamin (mg)] AS [Thiamin],
	vitamins.[Riboflavin (mg)] AS [Riboflavin],
	vitamins.[Niacin (mg)] AS [Niacin],
	vitamins.[Folate (µg)] AS [Folate]
FROM 
	[MyFoodDiary].[dbo].[Proximates] AS proximates
INNER JOIN
	[MyFoodDiary].[dbo].[Labelling] AS labelling
ON
	proximates.[Food Code] = labelling.[Food Code] AND (labelling.UserId = @userId OR labelling.UserId IS NULL)
INNER JOIN
	[MyFoodDiary].[dbo].[Inorganics] AS inorganics
ON
	proximates.[Food Code] = inorganics.[Food Code] AND (inorganics.UserId = @userId OR inorganics.UserId IS NULL)
INNER JOIN
	[MyFoodDiary].[dbo].[Vitamins] AS vitamins
ON
	proximates.[Food Code] = vitamins.[Food Code] AND (vitamins.UserId = @userId OR vitamins.UserId IS NULL)
WHERE 
	proximates.[Food Code] = @Code 
AND
	(proximates.[UserId] = @userId OR proximates.UserId IS NULL)
AND 
	labelling.IsDeleted = 0


GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProducts] (
	@userId nvarchar(128), @Food_Codes dbo.Food_Code_TVP READONLY
)
AS

SELECT 
	labels.[Food Code] AS Code, 
	labels.[Food Name] AS Name, 
	proximates.[Protein (g)] AS Protein,
	proximates.[Fat (g)] AS Fat,
	proximates.[Carbohydrate (g)] AS Carbohydrates,
	proximates.[Energy (kcal) (kcal)] AS Calories,
	proximates.[Alcohol (g)] AS Alcohol,
	proximates.[Total sugars (g)] AS [Total Sugars],
	proximates.[NSP (g)] AS [Fibre],
	proximates.[Cholesterol (mg)] AS Cholesterol,
  	inorganics.[Sodium (mg)] AS Sodium,
   	inorganics.[Potassium (mg)] AS Potassium,
   	inorganics.[Calcium (mg)] AS Calcium,
   	inorganics.[Magnesium (mg)] AS Magnesium,
   	inorganics.[Iron (mg)] AS Iron,
   	inorganics.[Copper (mg)] AS Copper,
   	inorganics.[Zinc (mg)] AS Zinc,
	inorganics.[Manganese (mg)] AS Manganese,
	inorganics.[Phosphorus (mg)] AS Phosphorus,
	inorganics.[Selenium (µg)] AS Selenium,
	vitamins.[Vitamin D (µg)] AS [Vitamin D],
	vitamins.[Vitamin C (mg)] AS [Vitamin C],	
	vitamins.[Vitamin E (mg)] AS [Vitamin E],	
	vitamins.[Vitamin K1 (µg)] AS [Vitamin K1],	
	vitamins.[Vitamin B6 (mg)] AS [Vitamin B6],	
	vitamins.[Vitamin B12 (µg)] AS [Vitamin B12], 
	vitamins.[Retinol Equivalent (µg)] AS [Vitamin A],
	vitamins.[Carotene (µg)] AS [Carotene],
	vitamins.[Pantothenate (mg)] AS [Pantothenic acid],
	vitamins.[Thiamin (mg)] AS [Thiamin],
	vitamins.[Riboflavin (mg)] AS [Riboflavin],
	vitamins.[Niacin (mg)] AS [Niacin],
	vitamins.[Folate (µg)] AS [Folate]
FROM 
	[MyFoodDiary].[dbo].[Proximates] AS proximates
INNER JOIN
	[MyFoodDiary].[dbo].[Labelling] AS labels
ON
	labels.[Food Code] = proximates.[Food Code] AND (labels.UserId = @userId OR labels.UserId IS NULL)
INNER JOIN
	[MyFoodDiary].[dbo].[Inorganics] AS inorganics
ON
	proximates.[Food Code] = inorganics.[Food Code] AND (inorganics.UserId = @userId OR inorganics.UserId IS NULL)
INNER JOIN
	[MyFoodDiary].[dbo].[Vitamins] AS vitamins
ON
	proximates.[Food Code] = vitamins.[Food Code] AND (vitamins.UserId = @userId OR vitamins.UserId IS NULL)
WHERE  
	(proximates.[UserId] = @userId OR proximates.UserId IS NULL)
AND
	labels.IsDeleted = 0
AND
	labels.[Food Code] IN
		(SELECT [Food Code] FROM @Food_Codes)


GO
/****** Object:  StoredProcedure [dbo].[GetTrackable]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackable](@id int)	
AS

SELECT 
	t.Id, t.Name
FROM 
	Trackables t
WHERE
	t.Id = @id



GO
/****** Object:  StoredProcedure [dbo].[GetTrackableItems]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackableItems](@dt datetime, @userId nvarchar(128))	
AS

SELECT 
	ti.Id, t.Id AS TrackableId, t.Name, ti.Amount AS Quantity
FROM 
	Trackables t
LEFT OUTER JOIN 
	TrackedItems ti	
ON
	t.Id = ti.TrackableId
AND
	ti.[Date] = @dt
WHERE
	t.UserId = @userId

GO
/****** Object:  StoredProcedure [dbo].[GetTrackables]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackables](@userId nvarchar(128))	
AS

SELECT 
	t.Id AS Id,
	t.Name AS Name
FROM 
	Trackables t
WHERE
	t.UserId = @userId


GO
/****** Object:  StoredProcedure [dbo].[InsertFoodItem]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertFoodItem](@Code varchar(255), @quantity int, @dt datetime, @userId nvarchar(128))	
AS
	
INSERT INTO 
	FoodItems
	(Code, Quantity, Date, UserId)
VALUES
	(@Code, @quantity, @dt, @userId)


GO
/****** Object:  StoredProcedure [dbo].[InsertIngredient]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertIngredient](@MealId int, @Code varchar(255))	
AS
	
INSERT INTO 
	Ingredients
	(MealId, Code, Quantity)
VALUES
	(@MealId, @Code, 0)



GO
/****** Object:  StoredProcedure [dbo].[InsertMeal]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertMeal](@UserId nvarchar(128), @Name varchar(255))	
AS
	
INSERT INTO 
	Meals
	(UserId, Name)
VALUES
	(@userId, @Name)



GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertProduct](@Code varchar(255), @Name varchar(255), @Protein varchar(255) = NULL, @Carbohydrate varchar(255) = NULL
									, @Fat varchar(255) = NULL, @Calories varchar(255) = NULL, @Alcohol varchar(255) = NULL, @TotalSugars varchar(255) = NULL
									, @VitaminD varchar(255) = NULL, @VitaminC varchar(255) = NULL, @Fibre varchar(255) = NULL
									, @VitaminE varchar(255) = NULL, @VitaminK1 varchar(255) = NULL, @VitaminB6 varchar(255) = NULL, @VitaminB12 varchar(255) = NULL
									, @VitaminA varchar(255) = NULL, @Carotene varchar(255) = NULL, @PantothenicAcid varchar(255) = NULL, @Thiamin varchar(255) = NULL
									, @Riboflavin varchar(255) = NULL, @Niacin varchar(255) = NULL, @Folate varchar(255) = NULL									
									, @Sodium varchar(255) = NULL, @Potassium varchar(255) = NULL, @Magnesium varchar(255) = NULL, @Iron varchar(255) = NULL
									, @Calcium varchar(255) = NULL, @Copper varchar(255) = NULL, @Zinc varchar(255) = NULL									
									, @Manganese varchar(255) = NULL, @Phosphorus varchar(255) = NULL, @Selenium varchar(255) = NULL, @UserId nvarchar(128))	
AS
	
INSERT INTO 
	Proximates
	([Group],[Food Code], [Food Name], [Protein (g)], [Carbohydrate (g)], [Fat (g)], [Energy (kcal) (kcal)], [Alcohol (g)], [Total sugars (g)], [NSP (g)], [UserId])
VALUES
	('CUSTOM', @Code, @Name, @Protein, @Carbohydrate, @Fat, @Calories, @Alcohol, @TotalSugars, @Fibre, @UserId)

	
INSERT INTO 
	Labelling
	([Group],[Food Code], [Food Name], [UserId])
VALUES
	('CUSTOM', @Code, @Name, @UserId)


INSERT INTO 
	Inorganics
	([Group],[Food Code], [Food Name], [Calcium (mg)], [Sodium (mg)], [Potassium (mg)], [Magnesium (mg)], [Iron (mg)], [Copper (mg)], [Zinc (mg)], 
	 [Manganese (mg)], [Phosphorus (mg)], [Selenium (µg)], [UserId])
VALUES
	('CUSTOM', @Code, @Name, @Calcium, @Sodium, @Potassium, @Magnesium, @Iron, @Copper, @Zinc, @Manganese, @Phosphorus, @Selenium, @UserId)

	

INSERT INTO 
	Vitamins
	([Group],[Food Code], [Food Name], [Vitamin D (µg)], [Vitamin C (mg)], [Vitamin E (mg)], [Vitamin K1 (µg)], [Vitamin B6 (mg)], [Vitamin B12 (µg)],
	 [Retinol Equivalent (µg)], [Carotene (µg)], [Pantothenate (mg)], [Thiamin (mg)], [Riboflavin (mg)], [Niacin (mg)], [Folate (µg)], [UserId])
VALUES
	('CUSTOM', @Code, @Name, @VitaminD, @VitaminC, @VitaminE, @VitaminK1, @VitaminB6, @VitaminB12, @VitaminA, @Carotene, @PantothenicAcid, @Thiamin, @Riboflavin, @Niacin, @Folate, @UserId)



	 



GO
/****** Object:  StoredProcedure [dbo].[InsertTrackable]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertTrackable](@UserId nvarchar(128), @Name varchar(255))	
AS
	
INSERT INTO 
	Trackables
	(UserId, Name)
VALUES
	(@userId, @Name)


GO
/****** Object:  StoredProcedure [dbo].[InsertTrackableItem]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertTrackableItem](@TrackableId int, @dt datetime, @Amount varchar(50) = NULL)	
AS
	
INSERT INTO 
	TrackedItems
	(TrackableId, Date, Amount)
VALUES
	(@TrackableId, @dt, @Amount)

GO
/****** Object:  StoredProcedure [dbo].[MergeFavourite]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MergeFavourite](@userId int, @id int, @quantity int)
AS

DECLARE @code VARCHAR(100)
SET @code = (SELECT fi.Code FROM FoodItems fi WHERE fi.Id = @id)

IF EXISTS (SELECT * FROM Favourites WHERE UserId = @userId AND Code = @code)
	UPDATE 
		Favourites
	SET 
		Quantity = @quantity
	WHERE 
		UserId = @userId
	AND
		Code = @code
ELSE
    INSERT INTO 
		Favourites (UserId, Code, Quantity)
	VALUES
		(@userId, @code, @quantity)


GO
/****** Object:  StoredProcedure [dbo].[UpdateFoodItem]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateFoodItem](@Id int, @Quantity int)	
AS

UPDATE 
	FoodItems
SET 
	Quantity = @Quantity
WHERE 
	Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[UpdateIngredient]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateIngredient](@Id int, @Quantity int)	
AS

UPDATE 
	Ingredients
SET 
	Quantity = @Quantity
WHERE 
	Id = @Id


GO
/****** Object:  StoredProcedure [dbo].[UpdateMeal]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateMeal](@Id int, @Name varchar(MAX))	
AS

UPDATE 
	Meals
SET 
	Name = @Name
WHERE 
	Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProduct](@Code varchar(255), @Name varchar(255), @Protein varchar(255) = NULL, @Carbohydrate varchar(255) = NULL
									, @Fat varchar(255) = NULL, @Calories varchar(255) = NULL, @Alcohol varchar(255) = NULL, @TotalSugars varchar(255) = NULL
									, @VitaminD varchar(255) = NULL, @VitaminC varchar(255) = NULL, @Fibre varchar(255) = NULL
									, @VitaminE varchar(255) = NULL, @VitaminK1 varchar(255) = NULL, @VitaminB6 varchar(255) = NULL, @VitaminB12 varchar(255) = NULL
									, @VitaminA varchar(255) = NULL, @Carotene varchar(255) = NULL, @PantothenicAcid varchar(255) = NULL, @Thiamin varchar(255) = NULL
									, @Riboflavin varchar(255) = NULL, @Niacin varchar(255) = NULL, @Folate varchar(255) = NULL									
									, @Sodium varchar(255) = NULL, @Potassium varchar(255) = NULL, @Magnesium varchar(255) = NULL, @Iron varchar(255) = NULL
									, @Calcium varchar(255) = NULL, @Copper varchar(255) = NULL, @Zinc varchar(255) = NULL									
									, @Manganese varchar(255) = NULL, @Phosphorus varchar(255) = NULL, @Selenium varchar(255) = NULL, @UserId nvarchar(128))	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

UPDATE [dbo].[Proximates]
SET [Food Name] = @Name,
	[Protein (g)] = @Protein,
	[Carbohydrate (g)] = @Carbohydrate,
	[Fat (g)] = @Fat,
	[Energy (kcal) (kcal)] = @Calories,
	[Alcohol (g)] = @Alcohol,
	[Total sugars (g)] = @TotalSugars,
	[NSP (g)] = @Fibre
WHERE [Food Code] = @Code AND [UserId] = @UserId


UPDATE [dbo].[Labelling]
SET [Food Name] = @Name
WHERE [Food Code] = @Code AND [UserId] = @UserId

UPDATE [dbo].[Inorganics]
SET [Food Name] = @Name,
	[Calcium (mg)] = @Calcium,
	[Sodium (mg)] = @Sodium,
	[Potassium (mg)] = @Potassium,
	[Magnesium (mg)] = @Magnesium,
	[Iron (mg)] = @Iron,
	[Copper (mg)] = @Copper,
	[Zinc (mg)] = @Zinc,
	[Manganese (mg)] = @Manganese,
	[Phosphorus (mg)] = @Phosphorus,
	[Selenium (µg)] = @Selenium	
WHERE [Food Code] = @Code AND [UserId] = @UserId

UPDATE [dbo].[Vitamins]
SET [Food Name] = @Name,
	[Vitamin D (µg)] = @VitaminD,
	[Vitamin C (mg)] = @VitaminC,
	[Vitamin E (mg)] = @VitaminE,
	[Vitamin K1 (µg)] = @VitaminK1,
	[Vitamin B6 (mg)] = @VitaminB6,
	[Vitamin B12 (µg)] = @VitaminB12,
	[Retinol Equivalent (µg)] = @VitaminA,
	[Carotene (µg)] = @Carotene,
	[Pantothenate (mg)] = @PantothenicAcid,
	[Thiamin (mg)] = @Thiamin,
	[Riboflavin (mg)] = @Riboflavin,
	[Niacin (mg)] = @Niacin,
	[Folate (µg)] = @Folate
WHERE [Food Code] = @Code AND [UserId] = @UserId

END


GO
/****** Object:  StoredProcedure [dbo].[UpdateTrackable]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTrackable](@Id int, @Name varchar(MAX))	
AS

UPDATE 
	Trackables
SET 
	Name = @Name
WHERE 
	Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[UpdateTrackableItem]    Script Date: 13/06/2019 06:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTrackableItem](@Id int, @Amount varchar(50) = NULL)	
AS

UPDATE 
	TrackedItems
SET 
	Amount = @Amount
WHERE 
	Id = @Id


GO
