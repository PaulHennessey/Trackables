USE [MyFoodDiary]
GO
/****** Object:  UserDefinedTableType [dbo].[Food_Code_TVP]    Script Date: 13/06/2019 06:10:22 ******/
CREATE TYPE [dbo].[Food_Code_TVP] AS TABLE(
	[Food Code] [varchar](255) NOT NULL
)
GO
