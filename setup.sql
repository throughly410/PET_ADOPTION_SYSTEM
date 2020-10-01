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
	N'��i, ���N�ʶR!!, ����, ���N����!!', N'�H��i�N���ʶR�A�i�H����h�����̧�@�Ӯa�A�]������H���A�X���d���C�ڬ۫H�H�P�d���������藍�O�R�����Y�C�d���N���ڭ̪��a�H�A�O�@���l������P�t���C',
	'N','ADMIN',GETDATE(),'ADMIN',GETDATE()
  )



--file:///C:/Users/Yu/Downloads/%E8%BE%B2%E5%A7%94%E6%9C%83OpenData+API%E4%BB%8B%E6%8E%A5%E8%AA%AA%E6%98%8E%E6%9B%B8-EIR065%E5%8B%95%E7%89%A9%E8%AA%8D%E9%A0%98%E9%A4%8A-v3.1%20(1).pdf
--https://github.com/donma/TaiwanAddressCityAreaRoadChineseEnglishJSON/blob/master/CityCountyData.json
	--SET_TYPE VARCHAR(12),
	--SET_ITEM VARCHAR(12),
	--PARAM_VALUE NVARCHAR(20),
	--PARAM_DESC NVARCHAR(36),
--����City

--�ϥΪ̨���Role
INSERT INTO SET_PARAM VALUES
('Role', 'User', '1', N'�ϥΪ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Role', 'Admin', '2', N'�޲z��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())
--���ADATA_STATE
INSERT INTO SET_PARAM VALUES
('DATA_STATE', 'Normal', 'N', N'���`', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('DATA_STATE', 'Delete', 'D', N'�w�R��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('DATA_STATE', 'Freeze', 'F', N'�ᵲ��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

--�ʧO
INSERT INTO SET_PARAM VALUES
('Sex', 'Male', '1', N'�k��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Sex', 'Female', '2', N'�k��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())


--�ʪ����OAnimalKind
INSERT INTO SET_PARAM VALUES
('AnimalKind', 'Cat', 'Cat', N'��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalKind', 'Dog', 'Dog', N'��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



INSERT INTO ANIMAL_BREED VALUES
('Cat',N'�V�ؿ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'���N��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�Xù���ſ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�^���ſ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�q��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�\��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�[���', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'��տ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�P�տ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'��ù��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�i��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'�^��u���', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'����u���', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Cat',N'��L��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�V�ت�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�Q��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�̮�|', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�����ٴ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�饻��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���h�_', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�k�갫����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�լ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���Y��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�^��d�z�h�y��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���s��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�j����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���I��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'Ĭ�X���Ϥ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�Τ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�j�պ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���v��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���¯�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�y����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���W', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�ڦN��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�i�d', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���J�L', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'þ�z', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�T��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�����y��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�ԥ��Ԧh', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'��I', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���Ƿ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�ڤ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�^�갫����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�_��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�g�A�~', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�B���s', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'��Ҫ��Ϥ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�_�ʤ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�ߺ��Զ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�f��S��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�谪�a�ձ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'������', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�j�N���Ϥ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'���갫����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'��Q�ɰ��Q�դ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�ǧJù��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�P���', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�߼ָ�', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'�i�h�y', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('Dog',N'��L��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())


--�ʪ��ʧOAnimalSex
INSERT INTO SET_PARAM VALUES
('AnimalSex', 'Male', 'M', N'��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSex', 'Female', 'F', N'��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSex', 'None', 'N', N'����J', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())
--�ʪ��~��Breed
--INSERT INTO SET_PARAM VALUES
--('Cat', '', '', '')


--�峹����PostKind
--
INSERT INTO SET_PARAM VALUES
('PostType', 'Adopt', '1', N'��i', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('PostType', 'Stray', '2', N'����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

---------
--�ʪ��髬AnimalBodytype
--[SMALL | MEDIUM | BIG]�]�p���B�����B�j���^
INSERT INTO SET_PARAM VALUES
('AnimalBodytype', 'SMALL', 'SMALL', N'�p��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBodytype', 'MEDIUM', 'MEDIUM', N'����', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBodytype', 'BIG', 'BIG', N'�j��', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



--�ʪ��~��Animalage 
--[CHILD | ADULT]�]���~�B���~�^
INSERT INTO SET_PARAM VALUES
('AnimalAge', 'CHILD', 'CHILD', N'���~', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalAge', 'ADULT', 'ADULT', N'���~', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



--�O�_���|AnimalSterilization
--[T | F | N]�]�O�B�_�B����J�^
INSERT INTO SET_PARAM VALUES
('AnimalSterilization', 'T', 'T', N'�O', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSterilization', 'F', 'F', N'�_', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalSterilization', 'N', 'N', N'����J', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

--�O�_�I���g���f�̭]AnimalBacterin
--[T | F | N]�]�O�B�_�B����J�^
INSERT INTO SET_PARAM VALUES
('AnimalBacterin', 'T', 'T', N'�O', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBacterin', 'F', 'F', N'�_', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalBacterin', 'N', 'N', N'����J', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())

--�ʪ����A AnimalStatus
--[NONE | OPEN | ADOPTED | OTHER | DEAD]
--�]�����i�B�}��{�i�B�w�{�i�B��L�B���`�^
INSERT INTO SET_PARAM VALUES
('AnimalStatus', 'NONE', 'NONE', N'�����i', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'OPEN', 'OPEN', N'�}��{�i', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'ADOPTED', 'ADOPTED', N'�w�{�i', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'OTHER', 'OTHER', N'��L', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE()),
('AnimalStatus', 'DEAD', 'DEAD', N'���`', 'N' , 'ADMIN', GETDATE(), 'ADMIN', GETDATE())



--INSERT INTO SET_PARAM VALUES
--('', '', '', '')






















--N'�V�ت�'
--N'�Q��'
--N'�̮�|'
--N'�����ٴ�'
--N'�饻��'
--N'���h�_'
--N'�k�갫����'
--N'�լ�'
--N'���Y��'
--N'�^��d�z�h�y��'
--N'���s��'
--N'�j����'
--N'���I��'
--N'�j���m'
--N'Ĭ�X���Ϥ�'
--N'�Τ�'
--N'�j�պ�'
--N'���v��'
--N'���¯�'
--N'�y����'
--N'���W'
--N'�ڦN��'
--N'����'
--N'�i�d'
--N'���J�L'
--N'þ�z'
--N'���'
--N'�T��'
--N'�����y��'
--N'�ԥ��Ԧh'
--N'��I'
--N'���Ƿ�'
--N'�ڤ�'
--N'�^�갫����'
--N'�_��'
--N'�g�A�~'
--N'�B���s'
--N'��Ҫ��Ϥ�'
--N'�_�ʤ�'
--N'�ߺ��Զ�'
--N'�f��S��'
--N'�谪�a�ձ�'
--N'���'
--N'������'
--N'��'
--N'�j�N���Ϥ�'
--N'���갫����'
--N'����'
--N'��Q�ɰ��Q�դ�'
--N'�ǧJù��'
--N'�P���'
--N'�߼ָ�'
--N'�i�h�y'
--N'��L��'

--N'�V�ؿ�'
--N'���N��'
--N'�Xù���ſ�'
--N'�^���ſ�'
--N'�q��'
--N'�\��'
--N'�[���'
--N'��տ�'
--N'�P�տ�'
--N'��ù��'
--N'�i��'
--N'�^��u���'
--N'����u���'
--N'��L��'