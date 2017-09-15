USE SuperheroesUniverse

/**

--- 1 ---

SELECT s.Id, s.Name
FROM Superheroes s
	INNER JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
	INNER JOIN Planets p ON ps.Planet_Id = p.Id
WHERE p.Name = 'Earth'



--- 2 ---

SELECT s.Name [Superhero],
	   p.Name + ' (' + pt.Name + ')' [Power]
FROM Superheroes s
	INNER JOIN PowerSuperheroes ps ON s.Id = ps.Superhero_Id
	INNER JOIN Powers p ON ps.Power_Id = p.Id
	INNER JOIN PowerTypes pt ON p.PowerTypeId = pt.Id

--- 3 ---

SELECT TOP 5 g.Planet, SUM(g.Protectors) [Protectors] FROM
(SELECT p.Name [Planet],
	   COUNT(s.Id) [Protectors]
FROM Superheroes s
	INNER JOIN Alignments a ON s.Alignment_Id = a.Id
	RIGHT JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
	RIGHT JOIN Planets p ON ps.Planet_Id = p.Id
WHERE a.Name = 'Good'
GROUP BY p.Name
UNION
SELECT p.Name [Planet],
	   0 [Protectors]
FROM Planets p
	INNER JOIN PlanetSuperheroes ps ON p.Id = ps.Planet_Id
	INNER JOIN Superheroes s ON ps.Superhero_Id = s.Id
	INNER JOIN Alignments a ON s.Alignment_Id = a.Id
		AND a.Name = 'Evil'
) g
GROUP BY g.Planet
ORDER BY Protectors DESC

--- 4 ---


GO

CREATE PROC usp_UpdateSuperheroBio
	  @superheroId INT,
	  @bio NVARCHAR(MAX)
AS
BEGIN
	UPDATE Superheroes
	SET Bio = @bio
	WHERE Id = @superheroId;
END

EXEC usp_UpdateSuperheroBio @superheroId = 1,
							@bio = N'Ironman was born in ...'



--- 5 ---
GO

CREATE PROC usp_GetSuperheroInfo
	  @superheroId INT
AS
BEGIN
	SELECT s.Id, s.Name, s.SecretIdentity [Secret Identity], s.Bio, a.Name [Alignment], p.Name [Planet], p1.Name [Power]
	FROM Superheroes s
		INNER JOIN Alignments a ON s.Alignment_Id = a.Id
		INNER JOIN PlanetSuperheroes ps ON s.Id = ps.Superhero_Id
		INNER JOIN Planets p ON ps.Planet_Id = p.Id
		INNER JOIN PowerSuperheroes ps1 ON s.Id = ps1.Superhero_Id
		INNER JOIN Powers p1 ON ps1.Power_Id = p1.Id
	WHERE s.Id = @superheroId
END

EXEC usp_GetSuperheroInfo @superheroId = 5



--- 6 ---

GO

CREATE PROC usp_GetPlanetsWithHeroesCount
AS
BEGIN
	SELECT g.Planet,
		   g.[Good Heroes],
		   g1.[Neutral Heroes],
		   g2.[Evil Heroes]
	FROM (
		SELECT p.Name [Planet],
			   COUNT(a.Name) [Good Heroes]
		FROM Planets p
			INNER JOIN PlanetSuperheroes ps ON p.Id = ps.Planet_Id
			INNER JOIN Superheroes s ON ps.Superhero_Id = s.Id
			INNER JOIN Alignments a ON s.Alignment_Id = a.Id
		WHERE a.Name = 'Good'
		GROUP BY p.Name
	) g
		INNER JOIN (
			SELECT p.Name [Planet],
				   COUNT(a.Name) [Neutral Heroes]
			FROM Planets p
				INNER JOIN PlanetSuperheroes ps ON p.Id = ps.Planet_Id
				INNER JOIN Superheroes s ON ps.Superhero_Id = s.Id
				INNER JOIN Alignments a ON s.Alignment_Id = a.Id
			WHERE a.Name = 'Neutral'
			GROUP BY p.Name
		) g1 ON g.Planet = g1.Planet
		INNER JOIN (
			SELECT p.Name [Planet],
				   COUNT(a.Name) [Evil Heroes]
			FROM Planets p
				INNER JOIN PlanetSuperheroes ps ON p.Id = ps.Planet_Id
				INNER JOIN Superheroes s ON ps.Superhero_Id = s.Id
				INNER JOIN Alignments a ON s.Alignment_Id = a.Id
			WHERE a.Name = 'Evil'
			GROUP BY p.Name
		) g2 ON g1.Planet = g2.Planet
END



--- 8 ---

GO

CREATE PROC usp_PowersUsageByAlignment
AS
BEGIN
	SELECT a.Name [Alignment],
		   COUNT(p.Name) [Powers Count]
	FROM Alignments a
		INNER JOIN Superheroes s ON a.Id = s.Alignment_Id
		INNER JOIN PowerSuperheroes ps ON s.Id = ps.Superhero_Id
		INNER JOIN Powers p ON ps.Power_Id = p.Id
	GROUP BY a.Name
END

EXEC usp_PowersUsageByAlignment



--- 7 ---
GO

CREATE PROC usp_CreateSuperhero
	  @name NVARCHAR(40),
	  @secretIdentity NVARCHAR(40),
	  @bio NTEXT,
	  @alignment NVARCHAR(40),
	  @planet NVARCHAR(40),
	  @powerOne NVARCHAR(40),
	  @typeForOne NVARCHAR(40),
	  @powerTwo NVARCHAR(40),
	  @typeForTwo NVARCHAR(40),
	  @powerThree NVARCHAR(40),
	  @typeForThree NVARCHAR(40)
AS
BEGIN
	IF NOT EXISTS(SELECT a.Name FROM Alignments a WHERE a.Name = @alignment)
	BEGIN
		INSERT INTO Alignments (Name)
		VALUES (@alignment);
	END

	IF NOT EXISTS(SELECT p.Name FROM Planets p WHERE p.Name = @planet)
	BEGIN
		INSERT INTO Planets (Name)
		VALUES (@planet);
	END

	IF NOT EXISTS(SELECT p.Name FROM Powers p WHERE p.Name = @powerOne)
	BEGIN
		INSERT INTO Powers (Name)
		VALUES (@powerOne);
	END

	IF NOT EXISTS(SELECT pt.Name FROM PowerTypes pt WHERE pt.Name = @typeForOne)
	BEGIN
		INSERT INTO PowerTypes (Name)
		VALUES (@typeForOne);
	END

	IF NOT EXISTS(SELECT p.Name FROM Powers p WHERE p.Name = @powerTwo)
	BEGIN
		INSERT INTO Powers (Name)
		VALUES (@powerTwo);
	END

	IF NOT EXISTS(SELECT pt.Name FROM PowerTypes pt WHERE pt.Name = @typeForTwo)
	BEGIN
		INSERT INTO PowerTypes (Name)
		VALUES (@typeForTwo);
	END

	IF NOT EXISTS(SELECT p.Name FROM Powers p WHERE p.Name = @powerThree)
	BEGIN
		INSERT INTO Powers (Name)
		VALUES (@powerThree);
	END

	IF NOT EXISTS(SELECT pt.Name FROM PowerTypes pt WHERE pt.Name = @typeForThree)
	BEGIN
		INSERT INTO PowerTypes (Name)
		VALUES (@typeForThree);
	END
END

*/
