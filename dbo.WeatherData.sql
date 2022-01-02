CREATE TABLE [dbo].[WeatherData]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Temperature] FLOAT NULL, 
    [WindSpeed] INT NULL, 
    [Pressure] INT NULL, 
    [DateTime] DATETIME NOT NULL
)
