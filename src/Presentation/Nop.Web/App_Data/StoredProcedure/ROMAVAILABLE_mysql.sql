USE `dibooking2021`;

DELIMITER //

CREATE PROCEDURE ROOMAVAILABLE ( 
	-- SQLINES DEMO *** s for the stored procedure here
	p_ArrivalDate DATETIME(3),
	p_DepartureDate DATETIME(3))
BEGIN
    -- SQLINES DEMO ***  for procedure here
	-- SQLINES LICENSE FOR EVALUATION USE ONLY
	SELECT * 
	FROM product
	WHERE Id NOT IN 
	(
		SELECT OI.ProductId as Id
		FROM   dibooking2021.order O
			   JOIN OrderItem OI
				   ON O.Id = OI.OrderId
		WHERE  ((OI.RentalStartDateUtc <= p_ArrivalDate AND OI.RentalEndDateUtc >= p_ArrivalDate)
			   OR (OI.RentalStartDateUtc < p_DepartureDate AND OI.RentalEndDateUtc >= p_DepartureDate )
			   OR (p_ArrivalDate <= OI.RentalStartDateUtc AND p_DepartureDate >= OI.RentalStartDateUtc))
			   AND O.Deleted = 0
	)
	AND IsRental = 1
	AND ((AvailableStartDateTimeUtc IS NOT NULL AND AvailableStartDateTimeUtc <= p_ArrivalDate) OR AvailableStartDateTimeUtc IS NULL)
	AND ((AvailableEndDateTimeUtc IS NOT NULL AND AvailableEndDateTimeUtc >= p_DepartureDate) OR AvailableEndDateTimeUtc IS NULL)
	AND Deleted = 0
	AND Published = 1;
END;
//

DELIMITER ;





