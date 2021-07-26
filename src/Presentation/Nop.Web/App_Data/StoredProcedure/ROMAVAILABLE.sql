USE [DiBookingDB]
GO

/****** Object:  StoredProcedure [dbo].[ROOMAVAILABLE]    Script Date: 26/07/2021 9:46:36 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ROOMAVAILABLE] 
	-- Add the parameters for the stored procedure here
	@ArrivalDate DATETIME,
	@DepartureDate DATETIME
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * 
	FROM [dbo].[Product]
	WHERE Id NOT IN 
	(
		SELECT OI.ProductId as Id
		FROM   [dbo].[Order] O
			   JOIN [dbo].[OrderItem] OI
				   ON O.Id = OI.OrderId
		WHERE  ((OI.RentalStartDateUtc <= @ArrivalDate AND OI.RentalEndDateUtc >= @ArrivalDate)
			   OR (OI.RentalStartDateUtc < @DepartureDate AND OI.RentalEndDateUtc >= @DepartureDate )
			   OR (@ArrivalDate <= OI.RentalStartDateUtc AND @DepartureDate >= OI.RentalStartDateUtc))
			   AND O.Deleted = 0
	)
	AND IsRental = 1
	AND ((AvailableStartDateTimeUtc IS NOT NULL AND AvailableStartDateTimeUtc <= @ArrivalDate) OR AvailableStartDateTimeUtc IS NULL)
	AND ((AvailableEndDateTimeUtc IS NOT NULL AND AvailableEndDateTimeUtc >= @DepartureDate) OR AvailableEndDateTimeUtc IS NULL)
	AND Deleted = 0
	AND Published = 1
END
GO


