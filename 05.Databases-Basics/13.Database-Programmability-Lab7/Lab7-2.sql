USE [SoftUni]
GO
/****** Object:  UserDefinedFunction [dbo].[udf_ProcessText]    Script Date: 08/10/2019 14:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[udf_ProcessText](@text NVARCHAR(50))
RETURNS NVARCHAR(50)
AS
BEGIN
	RETURN @text + ' some text'
END