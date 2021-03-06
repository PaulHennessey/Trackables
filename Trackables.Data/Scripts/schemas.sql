USE [MyFoodDiary]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 13/06/2019 05:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Factors]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[FactorsFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Favourites]    Script Date: 13/06/2019 05:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Favourites](
	[UserId] [int] NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FoodItems]    Script Date: 13/06/2019 05:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Quantity] [int] NULL,
	[Date] [datetime] NOT NULL,
	[UserId] [nvarchar](128) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Inorganics]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[InorganicsFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Labelling]    Script Date: 13/06/2019 05:52:02 ******/
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
	[IsDeleted] [bit] NULL CONSTRAINT [IsDeletedDefault]  DEFAULT ((0)),
	[UserId] [nvarchar](128) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meals]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[MUFAper100FA]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[MUFAper100gFood]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[NutrientFootnotes]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[NutrientFootnotesFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[OFAper100gFood]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[OFAper100gFoodFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[OrganicAcids]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[OrganicAcidsFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Phytosterols]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[PhytosterolsFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Proximates]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[ProximatesFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[PUFAper100gFA]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[PUFAper100gFood]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[SFAper100gFA]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[SFAper100gFood]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Trackables]    Script Date: 13/06/2019 05:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trackables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Name] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TrackedItems]    Script Date: 13/06/2019 05:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VitaminFractions]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[VitaminFractionsFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[Vitamins]    Script Date: 13/06/2019 05:52:02 ******/
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
/****** Object:  Table [dbo].[VitaminsFilterDatabase]    Script Date: 13/06/2019 05:52:02 ******/
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
