
CREATE DATABASE [HelloWorldCore6]
GO

CREATE LOGIN [HelloWorldCore6User] WITH PASSWORD=N'/n+t0W2EpKNMxv/RCjywOduteLRzA/ersXdgzKHOba4=', DEFAULT_DATABASE=[HelloWorldCore6], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [HelloWorldCore6]
GO

CREATE USER [HelloWorldCore6User] FOR LOGIN [HelloWorldCore6User] WITH DEFAULT_SCHEMA=[dbo]
GO
