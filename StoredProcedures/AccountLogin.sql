USE [OnlineShop]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Account_Login]    Script Date: 8/26/2018 12:59:41 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

--
-- Name:
--		Sp_Account_Login
--
-- Description:
--		Login procedure
--
-- Returns:
--		1 if successful
--		0 if failed
--
-- Security:
--		public
--
-- Notes:

CREATE PROCEDURE [dbo].[Sp_Account_Login]
	@UserName varchar(50),
	@Password varchar(20)
AS
BEGIN
	DECLARE @count	int
	DECLARE @res bit
	select @count = COUNT(*) from Account where UserName = @UserName and Password = @Password

	if @count > 0
		set @res = 1
	else
		set @res = 0
		
	select @res
END
