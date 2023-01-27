-- 1 Highest Peaks in Bulgaria
SELECT 
	c.CountryCode, 
	m.MountainRange, 
	p.PeakName, 
	p.Elevation
FROM
	Countries AS c 
JOIN MountainsCountries 
	AS mc ON c.CountryCode = mc.CountryCode
JOIN mountains 
	AS m ON m.id = mc.MountainId
JOIN peaks 
	AS p ON p.MountainId = mc.MountainId
WHERE
	c.CountryName = 'Bulgaria' AND p.elevation > 2835
ORDER BY 
	p.Elevation DESC;


-- 2 Count Mountain Ranges
SELECT 
    c.CountryCode, 
	COUNT(mc.MountainId) AS [MountainRanges]
FROM 
	Countries AS c
JOIN
    MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE
    c.CountryName IN ('United States' , 'Russia', 'Bulgaria')
GROUP BY 
	c.CountryCode
ORDER BY 
	MountainRanges DESC;


-- 3 Countries With or Without Rivers 
SELECT TOP (5)
	c.CountryName,
	r.RiverName
FROM 
	Countries AS c
LEFT JOIN 
	CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN 
	Rivers AS r ON r.Id = cr.RiverId
JOIN 
	Continents AS co ON co.ContinentCode = c.ContinentCode
WHERE 
	co.ContinentName = 'Africa'
ORDER BY 
	c.CountryName ASC


-- 4 Continents and Currencies
SELECT 
	C.ContinentCode, 
	c.CurrencyCode, 
	COUNT(*)
FROM 
	Countries as c
GROUP BY 
	c.ContinentCode, 
	c.CurrencyCode
HAVING 
	COUNT(*) > 1 AND COUNT(*) = 
		(
		SELECT TOP (1) COUNT(*)
		FROM 
			Countries AS cu
        WHERE 
			cu.ContinentCode = c.ContinentCode
        GROUP BY 
			cu.ContinentCode, cu.CurrencyCode
        ORDER BY 
			COUNT(*) DESC
		)
ORDER BY c.ContinentCode


-- 5 Countries Without any Mountains 
SELECT
	COUNT(*) AS [Count]
FROM 
	Countries
WHERE 
	CountryCode NOT IN
		(
		SELECT 
			CountryCode
		FROM
			MountainsCountries
		)


-- 6 Highest Peak and Longest River by Country
SELECT TOP (5)
	c.CountryName, 
	MAX(p.Elevation) AS [HighestPeakElevation], 
	MAX(r.Length) AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN 
	MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN 
	Peaks AS p ON mc.MountainId = p.MountainId 
LEFT JOIN 
	CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN 
	Rivers AS r ON cr.RiverId = r.Id
 GROUP BY 
	c.CountryName
 ORDER BY 
	HighestPeakElevation DESC, 
	LongestRiverLength DESC, 
	c.CountryName ASC

