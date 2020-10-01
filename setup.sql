--DROP DATABASE PET_ADOPTION_SYSTEM2;
CREATE DATABASE PET_ADOPTION_SYSTEM2;
GO
USE PET_ADOPTION_SYSTEM2;
CREATE TABLE MEMBER(
	ACCOUNT VARCHAR(16) NOT NULL,
	PASSWARD VARCHAR(24) NOT NULL,
	NAME NVARCHAR(20) NOT NULL,
	EMAIL NVARCHAR(56) NOT NULL,
	PHONE VARCHAR(10) NOT NULL,
	ROLE CHAR(1) NOT NULL,
	DATA_STATE CHAR(1) NOT NULL,
	CRT_USER VARCHAR(16),
	CRT_DATE DATETIME,
	MDF_USER VARCHAR(16),
	MDF_DATE DATETIME,
	CONSTRAINT PK_MEMBER PRIMARY KEY CLUSTERED
	(
		ACCOUNT
	)--WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 95) ON [PRIMARY]
) --ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

--PAD_INDEX
--STATISTICS_NORECOMPUTE
--IGNORE_DUP_KEY
--ALLOW_ROW_LOCKS
--ALLOW_PAGE_LOCKS
--FILLFACTOR
--TEXTIMAGE_ON
INSERT INTO MEMBER VALUES
(
	'ADMIN','qwer1234','SYSOP','test@google.com','0912345678' , 2, 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()
)

CREATE TABLE ANIMAL_POST
(
	POST_ID INT IDENTITY(1,1),
	TITLE NVARCHAR(24),
	CHIP_NO VARCHAR(15),
	ANIMAL_KIND VARCHAR(16),
	ANIMAL_SEX CHAR(1),
	ANIMAL_BREED VARCHAR(16),
	AREA_ID INT,
	REASON NVARCHAR(72),
	POST_TYPE INT,
	MEMO NVARCHAR(108),
	DATA_STATE CHAR(1),
	CRT_USER VARCHAR(16),
	CRT_DATE DATETIME,
	MDF_USER VARCHAR(16),
	MDF_DATE DATETIME,
	CONSTRAINT PK_ANIMAL_POST PRIMARY KEY CLUSTERED
	(
		POST_ID DESC
	)
)

CREATE TABLE ANIMAL_IMAGE
(
	POST_ID INT ,
	SEQ INT ,
	IMAGE_ADDRESS VARCHAR(47),
	DATA_STATE CHAR(1) NOT NULL,
	CRT_USER VARCHAR(16),
	CRT_DATE DATETIME,
	MDF_USER VARCHAR(16),
	MDF_DATE DATETIME,
	CONSTRAINT PK_ANIMAL_IMAGE PRIMARY KEY CLUSTERED
	(
		POST_ID
	)
)

CREATE TABLE SET_PARAM
(
	SET_TYPE VARCHAR(20) NOT NULL,
	SET_ITEM VARCHAR(20) NOT NULL,
	PARAM_VALUE NVARCHAR(28) NOT NULL,
	PARAM_DESC NVARCHAR(36) NOT NULL,
	DATA_STATE CHAR(1) NOT NULL,
	CRT_USER VARCHAR(16),
	CRT_DATE DATETIME,
	MDF_USER VARCHAR(16),
	MDF_DATE DATETIME,
	CONSTRAINT PK_SET_PARAM PRIMARY KEY CLUSTERED
	(
		SET_TYPE,SET_ITEM
	)
)

CREATE TABLE GUESTBOOK
(
	GUESTBOOK_ID INT IDENTITY(1,1),
	GUESTBOOK_MSG NVARCHAR(120) NOT NULL,
	DATA_STATE CHAR(1) NOT NULL,
	CRT_USER VARCHAR(16),
	CRT_DATE DATETIME,
	MDF_USER VARCHAR(16),
	MDF_DATE DATETIME,
	CONSTRAINT PK_GUESTBOOK PRIMARY KEY CLUSTERED
	(
		GUESTBOOK_ID
	)
)

CREATE TABLE ANIMAL_BREED
(
	ANIMAL_BREED_ID INT IDENTITY(1,1),
	ANIMAL_KIND NVARCHAR(16) NOT NULL,
	ANIMAL_BREED_NAME NVARCHAR(10) NOT NULL,
	DATA_STATE CHAR(1) NOT NULL,
	CRT_USER VARCHAR(16),
	CRT_DATE DATETIME,
	MDF_USER VARCHAR(16),
	MDF_DATE DATETIME,
	CONSTRAINT PK_ANIMAL_BREED PRIMARY KEY CLUSTERED
	(
		ANIMAL_BREED_ID
	)
)



CREATE TABLE CITY 
(
	CITY_ID INT IDENTITY(1,1),
	CITY_NAME NVARCHAR(4), 
	CITY_ENG_NAME VARCHAR(30),
	CONSTRAINT PK_CITY PRIMARY KEY CLUSTERED
	(
		CITY_ID
	)
);

CREATE TABLE AREA
(
	AREA_ID INT IDENTITY(1,1),
	CITY_ID INT NOT NULL,
	ZIP_CODE VARCHAR(3) NOT NULL,
	AREA_NAME NVARCHAR(4), 
	AREA_ENG_NAME NVARCHAR(30),
	CONSTRAINT PK_AREA PRIMARY KEY NONCLUSTERED
	(
		AREA_ID
	)
);
CREATE CLUSTERED INDEX IDX_AREA ON AREA (CITY_ID)
CREATE TABLE SHELTER
(
	animal_shelter_pkid INT PRIMARY KEY,
	shelter_name NVARCHAR(50)
)

CREATE TABLE ANNOUNCEMENT
(
	ANNOUNCE_ID int identity(1,1),
	TITLE NVARCHAR(24),
	CONTENT NVARCHAR(144),
	DATA_STATE CHAR(1) NOT NULL,
	CRT_USER VARCHAR(16),
	CRT_DATE DATETIME,
	MDF_USER VARCHAR(16),
	MDF_DATE DATETIME,
	CONSTRAINT PK_ANNOUNCEMENT PRIMARY KEY CLUSTERED
	(
		ANNOUNCE_ID
	)
)
  INSERT INTO [ANNOUNCEMENT] VALUES
  (
	N'領養, 取代購買!!, 結紮, 取代撲殺!!', N'以領養代替購買，可以讓更多浪浪們找一個家，也能夠讓人找到適合的寵物。我相信人與寵物之間絕對不是買賣關係。寵物就像我們的家人，是一輩子的陪伴與緣分。',
	'N','ADMIN',GETDATE(),'ADMIN',GETDATE()
  )



--file:///C:/Users/Yu/Downloads/%E8%BE%B2%E5%A7%94%E6%9C%83OpenData+API%E4%BB%8B%E6%8E%A5%E8%AA%AA%E6%98%8E%E6%9B%B8-EIR065%E5%8B%95%E7%89%A9%E8%AA%8D%E9%A0%98%E9%A4%8A-v3.1%20(1).pdf
--https://github.com/donma/TaiwanAddressCityAreaRoadChineseEnglishJSON/blob/master/CityCountyData.json
	--SET_TYPE VARCHAR(12),
	--SET_ITEM VARCHAR(12),
	--PARAM_VALUE NVARCHAR(20),
	--PARAM_DESC NVARCHAR(36),
--城市City

--使用者角色Role
INSERT INTO SET_PARAM VALUES
('Role', 'User', '1', N'使用者', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Role', 'Admin', '2', N'管理員', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())
--狀態DATA_STATE
INSERT INTO SET_PARAM VALUES
('DATA_STATE', 'Normal', 'N', N'正常', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('DATA_STATE', 'Delete', 'D', N'已刪除', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('DATA_STATE', 'Freeze', 'F', N'凍結中', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

--性別
INSERT INTO SET_PARAM VALUES
('Sex', 'Male', '1', N'男性', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Sex', 'Female', '2', N'女性', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())


--動物類別AnimalKind
INSERT INTO SET_PARAM VALUES
('AnimalKind', 'Cat', 'Cat', N'貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalKind', 'Dog', 'Dog', N'狗', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



INSERT INTO ANIMAL_BREED VALUES
('Cat',N'混種貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'金吉拉', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'俄羅斯藍貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'英國藍貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'緬絪', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'豹貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'加菲貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'折耳貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'摺耳貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'暹羅貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'波斯', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'英國短毛貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'美國短毛貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'其他貓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'混種狗', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'貴賓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'米格魯', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'馬爾濟斯', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'日本種', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'哈士奇', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'法國鬥牛犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'博美', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'牛頭梗', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'英國查理士獵犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'高山犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'大丹狗', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'阿富汗', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'蘇俄牧羊犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'敖犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'大白熊', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'拳師犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'挪威納', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'獵狐梗', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'狐狸', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'巴吉度', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'杜賓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'可卡', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'約克夏', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'臘腸', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'柴犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'狼犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'黃金獵犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'拉布拉多', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'西施', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'雪納瑞', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'巴戈', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'英國鬥牛犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'柯基', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'迷你品', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'伯恩山', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'邊境牧羊犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'北京犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'喜瑪拉雅', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'惠比特犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'西高地白梗', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'秋田', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'蝴蝶犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'比熊', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'古代牧羊犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'美國鬥牛犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'拉薩', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'比利時馬利諾犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'傑克羅素', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'鬆獅犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'喜樂蒂', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'波士頓', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'其他犬', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())


--動物性別AnimalSex
INSERT INTO SET_PARAM VALUES
('AnimalSex', 'Male', 'M', N'公', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSex', 'Female', 'F', N'母', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSex', 'None', 'N', N'未輸入', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())
--動物品種Breed
--INSERT INTO SET_PARAM VALUES
--('Cat', '', '', '')


--文章類型PostKind
--
INSERT INTO SET_PARAM VALUES
('PostType', 'Adopt', '1', N'領養', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('PostType', 'Stray', '2', N'走失', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

---------
--動物體型AnimalBodytype
--[SMALL | MEDIUM | BIG]（小型、中型、大型）
INSERT INTO SET_PARAM VALUES
('AnimalBodytype', 'SMALL', 'SMALL', N'小型', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBodytype', 'MEDIUM', 'MEDIUM', N'中型', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBodytype', 'BIG', 'BIG', N'大型', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



--動物年紀Animalage 
--[CHILD | ADULT]（幼年、成年）
INSERT INTO SET_PARAM VALUES
('AnimalAge', 'CHILD', 'CHILD', N'幼年', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalAge', 'ADULT', 'ADULT', N'成年', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



--是否絕育AnimalSterilization
--[T | F | N]（是、否、未輸入）
INSERT INTO SET_PARAM VALUES
('AnimalSterilization', 'T', 'T', N'是', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSterilization', 'F', 'F', N'否', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSterilization', 'N', 'N', N'未輸入', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

--是否施打狂犬病疫苗AnimalBacterin
--[T | F | N]（是、否、未輸入）
INSERT INTO SET_PARAM VALUES
('AnimalBacterin', 'T', 'T', N'是', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBacterin', 'F', 'F', N'否', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBacterin', 'N', 'N', N'未輸入', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

--動物狀態 AnimalStatus
--[NONE | OPEN | ADOPTED | OTHER | DEAD]
--（未公告、開放認養、已認養、其他、死亡）
INSERT INTO SET_PARAM VALUES
('AnimalStatus', 'NONE', 'NONE', N'未公告', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'OPEN', 'OPEN', N'開放認養', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'ADOPTED', 'ADOPTED', N'已認養', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'OTHER', 'OTHER', N'其他', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'DEAD', 'DEAD', N'死亡', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



--INSERT INTO SET_PARAM VALUES
--('', '', '', '')






















--N'混種狗'
--N'貴賓'
--N'米格魯'
--N'馬爾濟斯'
--N'日本種'
--N'哈士奇'
--N'法國鬥牛犬'
--N'博美'
--N'牛頭梗'
--N'英國查理士獵犬'
--N'高山犬'
--N'大丹狗'
--N'阿富汗'
--N'大麥町'
--N'蘇俄牧羊犬'
--N'敖犬'
--N'大白熊'
--N'拳師犬'
--N'挪威納'
--N'獵狐梗'
--N'狐狸'
--N'巴吉度'
--N'杜賓'
--N'可卡'
--N'約克夏'
--N'臘腸'
--N'柴犬'
--N'狼犬'
--N'黃金獵犬'
--N'拉布拉多'
--N'西施'
--N'雪納瑞'
--N'巴戈'
--N'英國鬥牛犬'
--N'柯基'
--N'迷你品'
--N'伯恩山'
--N'邊境牧羊犬'
--N'北京犬'
--N'喜瑪拉雅'
--N'惠比特犬'
--N'西高地白梗'
--N'秋田'
--N'蝴蝶犬'
--N'比熊'
--N'古代牧羊犬'
--N'美國鬥牛犬'
--N'拉薩'
--N'比利時馬利諾犬'
--N'傑克羅素'
--N'鬆獅犬'
--N'喜樂蒂'
--N'波士頓'
--N'其他犬'

--N'混種貓'
--N'金吉拉'
--N'俄羅斯藍貓'
--N'英國藍貓'
--N'緬絪'
--N'豹貓'
--N'加菲貓'
--N'折耳貓'
--N'摺耳貓'
--N'暹羅貓'
--N'波斯'
--N'英國短毛貓'
--N'美國短毛貓'
--N'其他貓'