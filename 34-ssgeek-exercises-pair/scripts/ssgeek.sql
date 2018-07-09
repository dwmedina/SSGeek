-- Switch to the system (aka master) database
USE master;
GO

-- Delete the SSGeek Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='SSGeek')
DROP DATABASE SSGeek;
GO

-- Create a new SSGeek Database
CREATE DATABASE SSGeek;
GO

-- Switch to the SSGeek Database
USE SSGeek
GO

create table forum_post
(
	id int identity(1,1),
	username varchar(200) not null,
	subject varchar(200) not null,
	message varchar(max) not null,
	post_date datetime default getdate(),
	
	constraint pk_forum_post_id primary key (id)
);


INSERT INTO forum_post VALUES ('neil a.', 'Aliens on the Moon', 'Did you know that Neil A. is Alien spelled backwards?', getdate());
INSERT INTO forum_post VALUES ('t_hanks', 'Favorite Movie?', 'My favorite space movie is Armageddon', getdate());

