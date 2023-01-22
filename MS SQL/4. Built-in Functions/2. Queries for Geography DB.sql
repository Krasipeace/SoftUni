-- 1 Countries holding 'A' 3 or more times
SELECT 
	CountryName AS [Country Name],
	IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode ASC


-- 2 Mix of peak and river names
SELECT 
	Peaks.PeakName, 
	Rivers.RiverName, 
	LOWER
		(
			(Peaks.PeakName) + SUBSTRING(Rivers.RiverName, 2, LEN(Rivers.Rivername))
		) 
	AS [Mix] 
FROM Peaks
JOIN Rivers
	ON RIGHT(Peaks.PeakName, 1) = LEFT(Rivers.RiverName, 1)
ORDER BY Mix ASC