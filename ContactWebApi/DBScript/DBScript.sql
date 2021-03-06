USE [ContactDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_Update]    Script Date: 8/4/2020 8:59:07 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ContactDetails_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ContactDetails_Update]
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_GetAll]    Script Date: 8/4/2020 8:59:07 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ContactDetails_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ContactDetails_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_Delete]    Script Date: 8/4/2020 8:59:07 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ContactDetails_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ContactDetails_Delete]
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_Add]    Script Date: 8/4/2020 8:59:07 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ContactDetails_Add]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ContactDetails_Add]
GO
/****** Object:  Table [dbo].[ContactDetails]    Script Date: 8/4/2020 8:59:07 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactDetails]') AND type in (N'U'))
DROP TABLE [dbo].[ContactDetails]
GO
/****** Object:  Table [dbo].[ContactDetails]    Script Date: 8/4/2020 8:59:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ContactDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_Add]    Script Date: 8/4/2020 8:59:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Shah
-- Create date: 08/03/2020
-- Description:	Add New Contact
-- =============================================
CREATE PROCEDURE [dbo].[USP_ContactDetails_Add]
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Email VARCHAR(100),
@PhoneNumber VARCHAR(20),
@Status BIT=0,
@ErrorCode VARCHAR(3) OUTPUT,
@ErrorMessage VARCHAR(50) OUTPUT,
@Result BIT OUTPUT
AS
BEGIN
     IF NOT EXISTS(SELECT TOP 1 1 From ContactDetails(NOLOCK) WHERE Email=@Email AND Status=1)
	 BEGIN
		 INSERT INTO ContactDetails
		 (
			FirstName
			,LastName
			,Email
			,PhoneNumber
			,[Status]
			,CreatedBy
			,CreatedDate
		 )
		 VALUES
		 (
			@FirstName
			,@LastName
			,@Email
			,@PhoneNumber
			,@Status
			,'ContactAPI'
			,GETDATE()
		 )
		SET @ErrorCode='200'
		SET @ErrorMessage='Success'
		SET @Result=1
		DECLARE @ContactID BIGINT
		SET @ContactID=SCOPE_IDENTITY()
		SELECT 
		ID,FirstName,LastName,Email,PhoneNumber,Status FROM 
		ContactDetails(NOLOCK) WHERE ID=@ContactID
		SELECT @ErrorCode AS ErrorCode,@ErrorMessage AS ErrorMessage,@Result AS  Result
	 END
	 ELSE 
	 BEGIN
		SET @ErrorCode='1001'
		SET @ErrorMessage='User is already exists.'
		SET @Result=0

		SELECT @ErrorCode AS ErrorCode,@ErrorMessage AS ErrorMessage,@Result AS  Result
	 END
	 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_Delete]    Script Date: 8/4/2020 8:59:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Shah
-- Create date: 08/03/2020
-- Description:	Delete Contact
-- =============================================
CREATE PROCEDURE [dbo].[USP_ContactDetails_Delete]
@ID BIGINT,
@ErrorCode VARCHAR(3) OUTPUT,
@ErrorMessage VARCHAR(50) OUTPUT,
@Result BIT OUTPUT
AS
BEGIN
	 IF EXISTS(SELECT TOP 1 1 From ContactDetails(NOLOCK) WHERE ID=@ID AND Status=1)
	 BEGIN
	 Update ContactDetails
	 SET [Status]=0 WHERE ID=@ID
	 
			SET @ErrorCode='200'
			SET @ErrorMessage='Success'
			SET @Result=1
	 END
	  ELSE 
	 BEGIN
		SET @ErrorCode='1001'
		SET @ErrorMessage='User is not exists.'
		SET @Result=0
	 END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_GetAll]    Script Date: 8/4/2020 8:59:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Shah
-- Create date: 08/03/2020
-- Description:	Update Contact
-- =============================================
CREATE PROCEDURE [dbo].[USP_ContactDetails_GetAll]
AS
BEGIN

	SELECT 
	ID
,FirstName
,LastName
,Email
,PhoneNumber
,Status
	FROM ContactDetails(NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ContactDetails_Update]    Script Date: 8/4/2020 8:59:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Shah
-- Create date: 08/03/2020
-- Description:	Update Contact
-- =============================================
CREATE PROCEDURE [dbo].[USP_ContactDetails_Update]
@ID BIGINT,
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Email VARCHAR(100),
@PhoneNumber VARCHAR(20),
@ErrorCode VARCHAR(3) OUTPUT,
@ErrorMessage VARCHAR(50) OUTPUT,
@Result BIT OUTPUT
AS
BEGIN
	 IF EXISTS(SELECT TOP 1 1 From ContactDetails(NOLOCK) WHERE Email=@Email AND ID=@ID AND Status=1)
	 BEGIN
		 UPDATE ContactDetails
		 SET FirstName=ISNULL(@FirstName,FirstName),
		 LastName=ISNULL(@LastName,LastName),
		 Email=ISNULL(@Email,Email),
		 PhoneNumber=ISNULL(@PhoneNumber,PhoneNumber),
		 UpdatedBy='ContactAPI',
		 UpdatedDate=GETDATE()
		 WHERE ID=@ID

			SET @ErrorCode='200'
			SET @ErrorMessage='Success'
			SET @Result=1

		SELECT 
		ID,FirstName,LastName,Email,PhoneNumber,Status FROM 
		ContactDetails(NOLOCK) WHERE ID=@ID
		SELECT @ErrorCode AS ErrorCode,@ErrorMessage AS ErrorMessage,@Result AS  Result
	 END
	  ELSE 
	 BEGIN
		SET @ErrorCode='1001'
		SET @ErrorMessage='User is not exists.'
		SET @Result=0

		SELECT @ErrorCode AS ErrorCode,@ErrorMessage AS ErrorMessage,@Result AS  Result
	 END
END
GO
