Use master


-- use only if there is already an old QuoridorDB
GO
DROP DATABASE QuoridorDB
GO  

Create Database QuoridorDB
GO

Use QuoridorDB
GO


Create Table Players (
PlayerID int identity primary key,
Email nvarchar(100) not null,
UserName nvarchar(100) not null,
FirstName nvarchar(30) not null,
LastName nvarchar(30) not null,
PlayerPass nvarchar(30) not null,
CONSTRAINT UC_Email UNIQUE(Email)
)
GO


Create Table Games (
GameID int identity primary key,
GameDate datetime not null, -- the date of the game
Player1ID int foreign key references Players(PlayerID),
Player2ID int foreign key references Players(PlayerID),
)
GO


Create Table GameMoves(
GameMoveID int identity primary key,
GameMoveGameID int not null foreign key references Games(GameID),
GameMovePlayerID int not null foreign key references Players(PlayerID),
SecondsFromStart int not null, -- time spent since the start (excluding this move) of the game for this payer ONLY
-- this value of the first move for a player is, of course, 0.
MoveTime int not null, -- the time (in seconds) this move took
IsPawnMove bit not null, -- tells if it's a pawn move or a block placement
x int not null, -- new x-value of the player / block placement
y int not null, -- new y-value of the player / block placement
BlockDirection char, -- if it is a block placement, tells the direction. Can include: 'U', 'D', 'L', 'R'
)
GO


-- responsible for including the ratinng changes for each player
Create Table RatingChanges(
RatingChangeID int identity primary key,
RatingChangePlayerID int foreign key references Players(PlayerID),
RatingChangeDate datetime not null, -- the date of the rating change
AlteredRating int not null, -- the rating after this game
)
GO


-- inserting sample data:
insert into Players values ('u1@gmail.com', 'u1', 'u1', 'u1', 'u1')
insert into Players values ('u2@gmail.com', 'u2', 'u2', 'u2', 'u2')
GO

insert into Games values ('2016-12-21 00:00:00.000', 1, 2)
GO

insert into GameMoves values (1, 1, 0, 8, 1, 1, 4, null)
insert into GameMoves values (1, 2, 0, 16, 0, 2, 3, 'U')
GO

insert into RatingChanges values (1, '2016-12-21 00:00:00.000', 1600)
insert into RatingChanges values (2, '2016-12-21 00:00:00.000', 1400)
GO
