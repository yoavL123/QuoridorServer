Use master
Create Database QuoridorDB
Go

Use QuoridorDB
Go


Create Table GameMoves(
GameMoveID int identity primary key,
GameMoveGameID int not null foreign key references Games(GameID),
GameMovePlayerID int not null foreign key references Players(PlayerID),
SecondsFromStart int not null, -- time spent since the start (excluding this move) of the game for this payer ONLY
-- this value of the first move for a player is, of course 0.
MoveTime int not null, -- the time this move took
IsPawnMove bit not null, -- tells if it's a pawn move or a block placement
int x, -- new x-value of the player / block placement
int y, -- new y-value of the player / block placemt
BlockDirection char, -- if it is a block placement, tels the drection. Can include: 'U', 'D', 'L', 'R'
)

Create Table Games (
GameID int identity primary key,
GameMoves nvarchar(300) not null,
GameTimeStamps nvarchar(300) not null,

)

Create Table Players (
PlayerID int identity primary key,
Email nvarchar(100) not null,
Username nvarchar(100) not null,
FirstName nvarchar(30) not null,
LastName nvarchar(30) not null,
PlayerPass nvarchar(30) not null,
CONSTRAINT UC_Email UNIQUE(Email)
)

Go

INSERT INTO Users VALUES ('kuku@kuku.com','kuku','kaka','1234');
GO
