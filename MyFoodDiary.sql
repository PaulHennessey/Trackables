USE [master]
GO
/****** Object:  Database [MyFoodDiary]    Script Date: 30/01/2021 09:11:21 ******/
CREATE DATABASE [MyFoodDiary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyFoodDiary', FILENAME = N'C:\Users\paul\MyFoodDiary.mdf' , SIZE = 29696KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyFoodDiary_log', FILENAME = N'C:\Users\paul\MyFoodDiary_log.ldf' , SIZE = 7616KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyFoodDiary] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyFoodDiary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyFoodDiary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyFoodDiary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyFoodDiary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyFoodDiary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyFoodDiary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyFoodDiary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyFoodDiary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyFoodDiary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyFoodDiary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyFoodDiary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyFoodDiary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyFoodDiary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyFoodDiary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyFoodDiary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyFoodDiary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyFoodDiary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyFoodDiary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyFoodDiary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyFoodDiary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyFoodDiary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyFoodDiary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyFoodDiary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyFoodDiary] SET RECOVERY FULL 
GO
ALTER DATABASE [MyFoodDiary] SET  MULTI_USER 
GO
ALTER DATABASE [MyFoodDiary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyFoodDiary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyFoodDiary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyFoodDiary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MyFoodDiary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyFoodDiary] SET QUERY_STORE = OFF
GO
USE [MyFoodDiary]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MyFoodDiary]
GO
/****** Object:  User [Network Service]    Script Date: 30/01/2021 09:11:21 ******/
CREATE USER [Network Service] FOR LOGIN [NT AUTHORITY\NETWORK SERVICE] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedTableType [dbo].[Food_Code_TVP]    Script Date: 30/01/2021 09:11:21 ******/
CREATE TYPE [dbo].[Food_Code_TVP] AS TABLE(
	[Food Code] [varchar](255) NOT NULL
)
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factors]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factors](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Edible proportion ()] [nvarchar](255) NULL,
	[Specific gravity ()] [nvarchar](255) NULL,
	[Total solids (g)] [nvarchar](255) NULL,
	[Nitrogen conversion factor ()] [nvarchar](255) NULL,
	[Glycerol conversion factor ()] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FactorsFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorsFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Edible proportion ()] [nvarchar](255) NULL,
	[Specific gravity ()] [nvarchar](255) NULL,
	[Total solids (g)] [nvarchar](255) NULL,
	[Nitrogen conversion factor ()] [nvarchar](255) NULL,
	[Glycerol conversion factor ()] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favourites]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favourites](
	[UserId] [int] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[MealId] [int] NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inorganics]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inorganics](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Sodium (mg)] [nvarchar](255) NULL,
	[Potassium (mg)] [nvarchar](255) NULL,
	[Calcium (mg)] [nvarchar](255) NULL,
	[Magnesium (mg)] [nvarchar](255) NULL,
	[Phosphorus (mg)] [nvarchar](255) NULL,
	[Iron (mg)] [nvarchar](255) NULL,
	[Copper (mg)] [nvarchar](255) NULL,
	[Zinc (mg)] [nvarchar](255) NULL,
	[Chloride (mg)] [nvarchar](255) NULL,
	[Manganese (mg)] [nvarchar](255) NULL,
	[Selenium (µg)] [nvarchar](255) NULL,
	[Iodine (µg)] [nvarchar](255) NULL,
	[UserId] [nvarchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InorganicsFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InorganicsFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Sodium (mg)] [nvarchar](255) NULL,
	[Potassium (mg)] [nvarchar](255) NULL,
	[Calcium (mg)] [nvarchar](255) NULL,
	[Magnesium (mg)] [nvarchar](255) NULL,
	[Phosphorus (mg)] [nvarchar](255) NULL,
	[Iron (mg)] [nvarchar](255) NULL,
	[Copper (mg)] [nvarchar](255) NULL,
	[Zinc (mg)] [nvarchar](255) NULL,
	[Chloride (mg)] [nvarchar](255) NULL,
	[Manganese (mg)] [nvarchar](255) NULL,
	[Selenium (µg)] [nvarchar](255) NULL,
	[Iodine (µg)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labelling]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labelling](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[LEnergy (kcal) (kcal)] [nvarchar](255) NULL,
	[LEnergy (kJ) (kJ)] [nvarchar](255) NULL,
	[LProtein (g)] [nvarchar](255) NULL,
	[LCarbohydrate (g)] [nvarchar](255) NULL,
	[LTotal Sugars (g)] [nvarchar](255) NULL,
	[LStarch (g)] [nvarchar](255) NULL,
	[IsDeleted] [bit] NULL,
	[UserId] [nvarchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MUFAper100FA]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MUFAper100FA](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[C10:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C10:1 /100g FA (g)] [nvarchar](255) NULL,
	[C12:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C12:1 /100g FA (g)] [nvarchar](255) NULL,
	[C14:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C14:1 /100g FA (g)] [nvarchar](255) NULL,
	[C15:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C15:1 /100g FA (g)] [nvarchar](255) NULL,
	[C16:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C16:1 /100g FA (g)] [nvarchar](255) NULL,
	[C17:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C17:1 /100g FA (g)] [nvarchar](255) NULL,
	[C18:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C18:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis/trans C18:1n-9 /100g FA (g)] [nvarchar](255) NULL,
	[cis/trans C18:1n-7 /100g FA (g)] [nvarchar](255) NULL,
	[C20:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C20:1 /100g FA (g)] [nvarchar](255) NULL,
	[C22:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C22:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis/trans C22:1n-11 /100g FA (g)] [nvarchar](255) NULL,
	[cis/trans C22:1n-9 /100g FA (g)] [nvarchar](255) NULL,
	[C24:1 /100g FA (g)] [nvarchar](255) NULL,
	[cis C24:1 /100g FA (g)] [nvarchar](255) NULL,
	[trans monounsaturated /100g FA (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MUFAper100gFood]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MUFAper100gFood](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[C10:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C10:1 /100g food (g)] [nvarchar](255) NULL,
	[C12:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C12:1 /100g food (g)] [nvarchar](255) NULL,
	[C14:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C14:1 /100g food (g)] [nvarchar](255) NULL,
	[C15:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C15:1 /100g food (g)] [nvarchar](255) NULL,
	[C16:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C16:1 /100g food (g)] [nvarchar](255) NULL,
	[C17:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C17:1 /100g food (g)] [nvarchar](255) NULL,
	[C18:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C18:1 /100g food (g)] [nvarchar](255) NULL,
	[cis/trans C18:1n-9 /100g food (g)] [nvarchar](255) NULL,
	[cis/trans C18:1n-7 /100g food (g)] [nvarchar](255) NULL,
	[C20:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C20:1 /100g food (g)] [nvarchar](255) NULL,
	[C22:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C22:1 /100g food (g)] [nvarchar](255) NULL,
	[cis/trans C22:1n-11 /100g food (g)] [nvarchar](255) NULL,
	[cis/trans C22:1n-9 /100g food (g)] [nvarchar](255) NULL,
	[C24:1 /100g food (g)] [nvarchar](255) NULL,
	[cis C24:1 /100g food (g)] [nvarchar](255) NULL,
	[trans monounsaturated /100g food (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NutrientFootnotes]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NutrientFootnotes](
	[GroupName] [nvarchar](255) NULL,
	[FoodCode] [nvarchar](255) NULL,
	[Food name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Footnote reference] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Nutrient FootNote] [nvarchar](255) NULL,
	[F9] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NutrientFootnotesFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NutrientFootnotesFilterDatabase](
	[GroupName] [nvarchar](255) NULL,
	[FoodCode] [nvarchar](255) NULL,
	[Food name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Footnote reference] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Nutrient FootNote] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OFAper100gFood]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OFAper100gFood](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[C16:UNID /100g food (g)] [nvarchar](255) NULL,
	[C20:UNID /100g food (g)] [nvarchar](255) NULL,
	[C22:UNID /100g food (g)] [nvarchar](255) NULL,
	[UNID /100g food (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OFAper100gFoodFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OFAper100gFoodFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[C16:UNID /100g food (g)] [nvarchar](255) NULL,
	[C20:UNID /100g food (g)] [nvarchar](255) NULL,
	[C22:UNID /100g food (g)] [nvarchar](255) NULL,
	[UNID /100g food (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganicAcids]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganicAcids](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Citric acid (g)] [nvarchar](255) NULL,
	[Malic acid (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganicAcidsFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganicAcidsFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Citric acid (g)] [nvarchar](255) NULL,
	[Malic acid (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phytosterols]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phytosterols](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Total Phytosterols (mg)] [nvarchar](255) NULL,
	[Other Cholesterol and Phytosterols (mg)] [nvarchar](255) NULL,
	[Phytosterol (mg)] [nvarchar](255) NULL,
	[Beta-sitosterol (mg)] [nvarchar](255) NULL,
	[Brassicasterol (mg)] [nvarchar](255) NULL,
	[Campesterol (mg)] [nvarchar](255) NULL,
	[Delta-5-avenasterol (mg)] [nvarchar](255) NULL,
	[Delta-7-avenasterol (mg)] [nvarchar](255) NULL,
	[Delta-7-stigmastenol (mg)] [nvarchar](255) NULL,
	[Stigmasterol (mg)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhytosterolsFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhytosterolsFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Total Phytosterols (mg)] [nvarchar](255) NULL,
	[Other Cholesterol and Phytosterols (mg)] [nvarchar](255) NULL,
	[Phytosterol (mg)] [nvarchar](255) NULL,
	[Beta-sitosterol (mg)] [nvarchar](255) NULL,
	[Brassicasterol (mg)] [nvarchar](255) NULL,
	[Campesterol (mg)] [nvarchar](255) NULL,
	[Delta-5-avenasterol (mg)] [nvarchar](255) NULL,
	[Delta-7-avenasterol (mg)] [nvarchar](255) NULL,
	[Delta-7-stigmastenol (mg)] [nvarchar](255) NULL,
	[Stigmasterol (mg)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proximates]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proximates](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Water (g)] [nvarchar](255) NULL,
	[Total nitrogen (g)] [nvarchar](255) NULL,
	[Protein (g)] [nvarchar](255) NULL,
	[Fat (g)] [nvarchar](255) NULL,
	[Carbohydrate (g)] [nvarchar](255) NULL,
	[Energy (kcal) (kcal)] [nvarchar](255) NULL,
	[Energy (kJ) (kJ)] [nvarchar](255) NULL,
	[Starch (g)] [nvarchar](255) NULL,
	[Oligosaccharide (g)] [nvarchar](255) NULL,
	[Total sugars (g)] [nvarchar](255) NULL,
	[Glucose (g)] [nvarchar](255) NULL,
	[Galactose (g)] [nvarchar](255) NULL,
	[Fructose (g)] [nvarchar](255) NULL,
	[Sucrose (g)] [nvarchar](255) NULL,
	[Maltose (g)] [nvarchar](255) NULL,
	[Lactose (g)] [nvarchar](255) NULL,
	[Alcohol (g)] [nvarchar](255) NULL,
	[NSP (g)] [nvarchar](255) NULL,
	[AOAC fibre (g)] [nvarchar](255) NULL,
	[Satd FA /100g FA (g)] [nvarchar](255) NULL,
	[Satd FA /100g fd (g)] [nvarchar](255) NULL,
	[n-6 poly /100g FA (g)] [nvarchar](255) NULL,
	[n-6 poly /100g food (g)] [nvarchar](255) NULL,
	[n-3 poly /100g FA (g)] [nvarchar](255) NULL,
	[n-3 poly /100g food (g)] [nvarchar](255) NULL,
	[cis-Mono FA /100g FA (g)] [nvarchar](255) NULL,
	[cis-Mono FA /100g Food (g)] [nvarchar](255) NULL,
	[Mono FA/ 100g FA (g)] [nvarchar](255) NULL,
	[Mono FA /100g food (g)] [nvarchar](255) NULL,
	[cis-Polyu FA /100g FA (g)] [nvarchar](255) NULL,
	[cis-Poly FA /100g Food (g)] [nvarchar](255) NULL,
	[Poly FA /100g FA (g)] [nvarchar](255) NULL,
	[Poly FA /100g food (g)] [nvarchar](255) NULL,
	[Sat FA excl Br /100g FA (g)] [nvarchar](255) NULL,
	[Sat FA excl Br /100g food (g)] [nvarchar](255) NULL,
	[Branched chain FA /100g FA (g)] [nvarchar](255) NULL,
	[Branched chain FA /100g food (g)] [nvarchar](255) NULL,
	[Trans FAs /100g FA (g)] [nvarchar](255) NULL,
	[Trans FAs /100g food (g)] [nvarchar](255) NULL,
	[Cholesterol (mg)] [nvarchar](255) NULL,
	[UserId] [nvarchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProximatesFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProximatesFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Water (g)] [nvarchar](255) NULL,
	[Total nitrogen (g)] [nvarchar](255) NULL,
	[Protein (g)] [nvarchar](255) NULL,
	[Fat (g)] [nvarchar](255) NULL,
	[Carbohydrate (g)] [nvarchar](255) NULL,
	[Energy (kcal) (kcal)] [nvarchar](255) NULL,
	[Energy (kJ) (kJ)] [nvarchar](255) NULL,
	[Starch (g)] [nvarchar](255) NULL,
	[Oligosaccharide (g)] [nvarchar](255) NULL,
	[Total sugars (g)] [nvarchar](255) NULL,
	[Glucose (g)] [nvarchar](255) NULL,
	[Galactose (g)] [nvarchar](255) NULL,
	[Fructose (g)] [nvarchar](255) NULL,
	[Sucrose (g)] [nvarchar](255) NULL,
	[Maltose (g)] [nvarchar](255) NULL,
	[Lactose (g)] [nvarchar](255) NULL,
	[Alcohol (g)] [nvarchar](255) NULL,
	[NSP (g)] [nvarchar](255) NULL,
	[AOAC fibre (g)] [nvarchar](255) NULL,
	[Satd FA /100g FA (g)] [nvarchar](255) NULL,
	[Satd FA /100g fd (g)] [nvarchar](255) NULL,
	[n-6 poly /100g FA (g)] [nvarchar](255) NULL,
	[n-6 poly /100g food (g)] [nvarchar](255) NULL,
	[n-3 poly /100g FA (g)] [nvarchar](255) NULL,
	[n-3 poly /100g food (g)] [nvarchar](255) NULL,
	[cis-Mono FA /100g FA (g)] [nvarchar](255) NULL,
	[cis-Mono FA /100g Food (g)] [nvarchar](255) NULL,
	[Mono FA/ 100g FA (g)] [nvarchar](255) NULL,
	[Mono FA /100g food (g)] [nvarchar](255) NULL,
	[cis-Polyu FA /100g FA (g)] [nvarchar](255) NULL,
	[cis-Poly FA /100g Food (g)] [nvarchar](255) NULL,
	[Poly FA /100g FA (g)] [nvarchar](255) NULL,
	[Poly FA /100g food (g)] [nvarchar](255) NULL,
	[Sat FA excl Br /100g FA (g)] [nvarchar](255) NULL,
	[Sat FA excl Br /100g food (g)] [nvarchar](255) NULL,
	[Branched chain FA /100g FA (g)] [nvarchar](255) NULL,
	[Branched chain FA /100g food (g)] [nvarchar](255) NULL,
	[Trans FAs /100g FA (g)] [nvarchar](255) NULL,
	[Trans FAs /100g food (g)] [nvarchar](255) NULL,
	[Cholesterol (mg)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PUFAper100gFA]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PUFAper100gFA](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[cis C16:3 /100g FA (g)] [nvarchar](255) NULL,
	[C16:4 /100g FA (g)] [nvarchar](255) NULL,
	[C18:2 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C18:2 /100g FA (g)] [nvarchar](255) NULL,
	[C18:3 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-3 C18:3 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C18:3 /100g FA (g)] [nvarchar](255) NULL,
	[C18:4 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-3 C18:4 /100g FA (g)] [nvarchar](255) NULL,
	[unknown C18 poly /100g FA (g)] [nvarchar](255) NULL,
	[C20:2 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C20:2 /100g FA (g)] [nvarchar](255) NULL,
	[C20:3 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C20:3 /100g FA (g)] [nvarchar](255) NULL,
	[C20:4 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C20:4 /100g FA (g)] [nvarchar](255) NULL,
	[C20:5 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-3 C20:5 /100g FA (g)] [nvarchar](255) NULL,
	[unknown C20 poly /100 FA (g)] [nvarchar](255) NULL,
	[C21:5 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-3 C21:5 /100g FA (g)] [nvarchar](255) NULL,
	[C22:2 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C22:2 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C22:3 /100g FA (g)] [nvarchar](255) NULL,
	[C22:4 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-6 C22:4 /100g FA (g)] [nvarchar](255) NULL,
	[C22:5 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-3 C22:5 /100g FA (g)] [nvarchar](255) NULL,
	[C22:6 /100g FA (g)] [nvarchar](255) NULL,
	[cis n-3 C22:6 /100g FA (g)] [nvarchar](255) NULL,
	[unknown C22 poly /100g FA (g)] [nvarchar](255) NULL,
	[trans poly /100g FA (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PUFAper100gFood]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PUFAper100gFood](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[C16:2 /100g food (g)] [nvarchar](255) NULL,
	[cis C16:2 /100g food (g)] [nvarchar](255) NULL,
	[C16:3 /100g food (g)] [nvarchar](255) NULL,
	[C16:4 /100g food (g)] [nvarchar](255) NULL,
	[cis C16:4 /100g food (g)] [nvarchar](255) NULL,
	[unknown C16 poly /100g food (g)] [nvarchar](255) NULL,
	[C18:2 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C18:2 /100g food (g)] [nvarchar](255) NULL,
	[C18:3 /100g food (g)] [nvarchar](255) NULL,
	[cis n-3 C18:3 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C18:3 /100g food (g)] [nvarchar](255) NULL,
	[C18:4 /100g food (g)] [nvarchar](255) NULL,
	[cis n-3 C18:4 /100g food (g)] [nvarchar](255) NULL,
	[unknown C18 poly /100g food (g)] [nvarchar](255) NULL,
	[C20:2 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C20:2 /100g food (g)] [nvarchar](255) NULL,
	[C20:3 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C20:3 /100g food (g)] [nvarchar](255) NULL,
	[C20:4 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C20:4 /100g food (g)] [nvarchar](255) NULL,
	[C20:5 /100g food (g)] [nvarchar](255) NULL,
	[cis n-3 C20:5 /100g food (g)] [nvarchar](255) NULL,
	[unknown C20 poly /100g food (g)] [nvarchar](255) NULL,
	[C21:5 /100g food (g)] [nvarchar](255) NULL,
	[cis n-3 C21:5 /100g food (g)] [nvarchar](255) NULL,
	[C22:2 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C22:2 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C22:3 /100g food (g)] [nvarchar](255) NULL,
	[C22:4 /100g food (g)] [nvarchar](255) NULL,
	[cis n-6 C22:4 /100g food (g)] [nvarchar](255) NULL,
	[C22:5 /100g food (g)] [nvarchar](255) NULL,
	[cis n-3 C22:5 /100g food (g)] [nvarchar](255) NULL,
	[C22:6 /100g food (g)] [nvarchar](255) NULL,
	[cis n-3 C22:6 /100g food (g)] [nvarchar](255) NULL,
	[unknown C22 poly /100g food (g)] [nvarchar](255) NULL,
	[trans poly /100g food (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servings]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Quantity] [int] NULL,
	[Date] [datetime] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SFAper100gFA]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SFAper100gFA](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[C4:0 /100g FA (g)] [nvarchar](255) NULL,
	[C6:0 /100g FA (g)] [nvarchar](255) NULL,
	[C8:0 /100g FA (g)] [nvarchar](255) NULL,
	[C10:0 /100g FA (g)] [nvarchar](255) NULL,
	[C11:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C12:0 /100g FA (g)] [nvarchar](255) NULL,
	[C12:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C13:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C14:0 /100g FA (g)] [nvarchar](255) NULL,
	[C14:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C15:0 /100g FA (g)] [nvarchar](255) NULL,
	[C15:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C16:0 /100g FA (g)] [nvarchar](255) NULL,
	[C16:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C17:0 /100g FA (g)] [nvarchar](255) NULL,
	[C17:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C18:0 /100g FA (g)] [nvarchar](255) NULL,
	[C18:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C20:0 /100g FA (g)] [nvarchar](255) NULL,
	[C20:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C22:0 /100g FA (g)] [nvarchar](255) NULL,
	[C22:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C24:0 /100g FA (g)] [nvarchar](255) NULL,
	[C24:0 ex Br /100g FA (g)] [nvarchar](255) NULL,
	[C25:0 ex Br /100g FA (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SFAper100gFood]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SFAper100gFood](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[C4:0 /100g food (g)] [nvarchar](255) NULL,
	[C6:0 /100g food (g)] [nvarchar](255) NULL,
	[C8:0 /100g food (g)] [nvarchar](255) NULL,
	[C10:0 /100g food (g)] [nvarchar](255) NULL,
	[C11:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C12:0 /100g food (g)] [nvarchar](255) NULL,
	[C12:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C13:0 /100g food (g)] [nvarchar](255) NULL,
	[C13:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C14:0 /100g food (g)] [nvarchar](255) NULL,
	[C14:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C15:0 /100g food (g)] [nvarchar](255) NULL,
	[C15:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C16:0 /100g food (g)] [nvarchar](255) NULL,
	[C16:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C17:0 /100g food (g)] [nvarchar](255) NULL,
	[C17:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C18:0 /100g food (g)] [nvarchar](255) NULL,
	[C18:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C19:0 /100g food (g)] [nvarchar](255) NULL,
	[C20:0 /100g food (g)] [nvarchar](255) NULL,
	[C20:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C22:0 /100g food (g)] [nvarchar](255) NULL,
	[C22:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C24:0 /100g food (g)] [nvarchar](255) NULL,
	[C24:0 ex Br /100g food (g)] [nvarchar](255) NULL,
	[C25:0 ex Br /100g food (g)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trackables]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trackables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Name] [varchar](max) NULL,
 CONSTRAINT [PK__Trackabl__3214EC07ABC6CDF6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrackedItems]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackedItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrackableId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VitaminFractions]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VitaminFractions](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[All-trans-retinol (µg)] [nvarchar](255) NULL,
	[13-cis-retinol (µg)] [nvarchar](255) NULL,
	[Dehydroretinol (µg)] [nvarchar](255) NULL,
	[Retinaldehyde (µg)] [nvarchar](255) NULL,
	[Alpha-carotene (µg)] [nvarchar](255) NULL,
	[Beta-carotene (µg)] [nvarchar](255) NULL,
	[Cryptoxanthins (µg)] [nvarchar](255) NULL,
	[Lutein (µg)] [nvarchar](255) NULL,
	[Lycopene (µg)] [nvarchar](255) NULL,
	[25-hydroxy vitamin D3 (µg)] [nvarchar](255) NULL,
	[Cholecalciferol (µg)] [nvarchar](255) NULL,
	[5-mehtyl folate (µg)] [nvarchar](255) NULL,
	[Alpha-tocopherol (mg)] [nvarchar](255) NULL,
	[Beta-tocopherol (mg)] [nvarchar](255) NULL,
	[Delta-tocopherol (mg)] [nvarchar](255) NULL,
	[Gamma-tocopherol (mg)] [nvarchar](255) NULL,
	[Alpha-tocotrienol (mg)] [nvarchar](255) NULL,
	[Delta-tocotrienol (mg)] [nvarchar](255) NULL,
	[Gamma-tocotrienol (mg)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VitaminFractionsFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VitaminFractionsFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[All-trans-retinol (µg)] [nvarchar](255) NULL,
	[13-cis-retinol (µg)] [nvarchar](255) NULL,
	[Dehydroretinol (µg)] [nvarchar](255) NULL,
	[Retinaldehyde (µg)] [nvarchar](255) NULL,
	[Alpha-carotene (µg)] [nvarchar](255) NULL,
	[Beta-carotene (µg)] [nvarchar](255) NULL,
	[Cryptoxanthins (µg)] [nvarchar](255) NULL,
	[Lutein (µg)] [nvarchar](255) NULL,
	[Lycopene (µg)] [nvarchar](255) NULL,
	[25-hydroxy vitamin D3 (µg)] [nvarchar](255) NULL,
	[Cholecalciferol (µg)] [nvarchar](255) NULL,
	[5-mehtyl folate (µg)] [nvarchar](255) NULL,
	[Alpha-tocopherol (mg)] [nvarchar](255) NULL,
	[Beta-tocopherol (mg)] [nvarchar](255) NULL,
	[Delta-tocopherol (mg)] [nvarchar](255) NULL,
	[Gamma-tocopherol (mg)] [nvarchar](255) NULL,
	[Alpha-tocotrienol (mg)] [nvarchar](255) NULL,
	[Delta-tocotrienol (mg)] [nvarchar](255) NULL,
	[Gamma-tocotrienol (mg)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vitamins]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vitamins](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Retinol (µg)] [nvarchar](255) NULL,
	[Carotene (µg)] [nvarchar](255) NULL,
	[Retinol Equivalent (µg)] [nvarchar](255) NULL,
	[Vitamin D (µg)] [nvarchar](255) NULL,
	[Vitamin E (mg)] [nvarchar](255) NULL,
	[Vitamin K1 (µg)] [nvarchar](255) NULL,
	[Thiamin (mg)] [nvarchar](255) NULL,
	[Riboflavin (mg)] [nvarchar](255) NULL,
	[Niacin (mg)] [nvarchar](255) NULL,
	[Tryptophan/60 (mg)] [nvarchar](255) NULL,
	[Niacin equivalent (mg)] [nvarchar](255) NULL,
	[Vitamin B6 (mg)] [nvarchar](255) NULL,
	[Vitamin B12 (µg)] [nvarchar](255) NULL,
	[Folate (µg)] [nvarchar](255) NULL,
	[Pantothenate (mg)] [nvarchar](255) NULL,
	[Biotin (µg)] [nvarchar](255) NULL,
	[Vitamin C (mg)] [nvarchar](255) NULL,
	[UserId] [nvarchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VitaminsFilterDatabase]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VitaminsFilterDatabase](
	[Food Code] [nvarchar](255) NULL,
	[Food Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Group] [nvarchar](255) NULL,
	[Constant] [nvarchar](255) NULL,
	[Previous] [nvarchar](255) NULL,
	[Comments] [nvarchar](255) NULL,
	[Description Footnote] [nvarchar](255) NULL,
	[Retinol (µg)] [nvarchar](255) NULL,
	[Carotene (µg)] [nvarchar](255) NULL,
	[Retinol Equivalent (µg)] [nvarchar](255) NULL,
	[Vitamin D (µg)] [nvarchar](255) NULL,
	[Vitamin E (mg)] [nvarchar](255) NULL,
	[Vitamin K1 (µg)] [nvarchar](255) NULL,
	[Thiamin (mg)] [nvarchar](255) NULL,
	[Riboflavin (mg)] [nvarchar](255) NULL,
	[Niacin (mg)] [nvarchar](255) NULL,
	[Tryptophan/60 (mg)] [nvarchar](255) NULL,
	[Niacin equivalent (mg)] [nvarchar](255) NULL,
	[Vitamin B6 (mg)] [nvarchar](255) NULL,
	[Vitamin B12 (µg)] [nvarchar](255) NULL,
	[Folate (µg)] [nvarchar](255) NULL,
	[Pantothenate (mg)] [nvarchar](255) NULL,
	[Biotin (µg)] [nvarchar](255) NULL,
	[Vitamin C (mg)] [nvarchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 30/01/2021 09:11:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 30/01/2021 09:11:21 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 30/01/2021 09:11:21 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 30/01/2021 09:11:21 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 30/01/2021 09:11:21 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 30/01/2021 09:11:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Labelling] ADD  CONSTRAINT [IsDeletedDefault]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[DeleteFavourite]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteIngredient]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteMeal]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteServing]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteServing](@Id int)	
AS

DELETE FROM
	Servings
WHERE 
	Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[DeleteTrackable]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetCustomProductCount]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetCustomProducts]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetFavourites]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetIngredients]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetMeal]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetMeals]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetProduct]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetServing]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetServing](@Code nvarchar(255))	
AS

SELECT 
	s.Id, s.Code, l.[Food Name] AS Name, s.Quantity, s.Date
FROM 
	Servings s
INNER JOIN
	MyFoodDiary.dbo.Labelling l
ON
	s.Code = l.[Food Code] Collate SQL_Latin1_General_CP1_CI_AS
WHERE
	s.Code = @Code
AND 
	l.IsDeleted = 0

GO
/****** Object:  StoredProcedure [dbo].[GetServings]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetServings](@dt datetime, @userId nvarchar(128))	
AS

SELECT 
	s.Id, s.Code, l.[Food Name] AS Name, s.Quantity, s.Date, s.UserId
FROM 
	Servings s
INNER JOIN
	MyFoodDiary.dbo.Labelling l
ON
	s.Code = l.[Food Code] Collate SQL_Latin1_General_CP1_CI_AS
WHERE
	s.[Date] = @dt
AND 
	s.UserId = @userId
AND 
	l.IsDeleted = 0
AND 
	(l.UserId = @userId OR l.UserId IS NULL)


GO
/****** Object:  StoredProcedure [dbo].[GetTrackable]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetTrackableItem]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTrackableItem](@dt datetime, @trackableId int)	
AS

SELECT 
	t.Name, ti.Amount AS Quantity, @dt AS Date
FROM 
	Trackables t
LEFT OUTER JOIN 
	TrackedItems ti	
ON
	t.Id = ti.TrackableId
AND
	ti.[Date] = @dt
WHERE
	t.Id = @trackableId
GO
/****** Object:  StoredProcedure [dbo].[GetTrackableItems]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[GetTrackables]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertIngredient]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertMeal]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertServing]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertServing](@Code varchar(255), @quantity int, @dt datetime, @userId nvarchar(128))	
AS
	
INSERT INTO 
	Servings
	(Code, Quantity, Date, UserId)
VALUES
	(@Code, @quantity, @dt, @userId)

GO
/****** Object:  StoredProcedure [dbo].[InsertTrackable]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertTrackableItem]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[MergeFavourite]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateIngredient]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateMeal]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateServing]    Script Date: 30/01/2021 09:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateServing](@Id int, @Quantity int)	
AS

UPDATE 
	Servings
SET 
	Quantity = @Quantity
WHERE 
	Id = @Id

GO
/****** Object:  StoredProcedure [dbo].[UpdateTrackable]    Script Date: 30/01/2021 09:11:21 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateTrackableItem]    Script Date: 30/01/2021 09:11:21 ******/
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
USE [master]
GO
ALTER DATABASE [MyFoodDiary] SET  READ_WRITE 
GO
