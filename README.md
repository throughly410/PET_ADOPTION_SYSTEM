# PET_ADOPTION_SYSTEM

專案介紹
動機

分層架構
主專案
NLOG

Models

Services

Dacs
Dapper

## 系統介紹

# 資料庫Schema
會員資料表
送養寵物資料表
走失寵物資料表
系統資料表
留言資料表

狀態
N '正常使用中'
D '已刪除'
F '凍結中'

使用者角色
1 'USER'
2 'ADMIN'

動物類別 -> 動物品種
動物性別

系統代碼  ANIMAL
系統參數  DOG
數值      Labrador
描述      拉不拉多


系統代碼  City
系統參數  New Taipei City
數值      
描述  

系統代碼  ROLE
系統參數  ACCOUNT
數值  'USER'
描述  '使用者'


系統代碼  DATA_STATE
系統參數  DATA
數值  'N'
描述  '正常使用中'

城市
使用者角色
狀態
動物類別
動物性別
動物品種
文章類型

-------
動物體型
動物年紀
是否絕育
是否施打狂犬病疫苗
動物狀態



## 會員資料表 MEMBER
|項目|欄位名稱|主外鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   ACCOUNT|   P|   N|   VARCHAR(16)|   |   會員編號|
|2|   PASSWARD|   |   N|   VARCHAR(24)|   |   密碼|
|2|   NAME|   |      N|   NVARCHAR(20)|   |姓名|
|3|   EMAIL|   |      N|   NVARCHAR(56)|   |聯絡信箱|
|4|   PHONE|   |      N|   VARCHAR(10)|   |連絡電話|
|4|   ROLE|   |      N|   CHAR(1)|   |使用者角色|
|4|   DATA_STATE|   |   N|   CHAR(1)|   'N'|   狀態|
|5|   CRT_USER|   |   Y|      VARCHAR(16)|   |建立人員|
|6|   CRT_DATE|   |   Y|      DATETIME|   GETDATE()|建立日期|
|7|   MDF_USER|   |   Y|      VARCHAR(16)|   |修改人員|
|8|   MDF_DATE|   |   Y|      DATETIME|   GETDATE()|修改日期|

## 寵物文章資料表(送養或走失)
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   POST_ID|   P|   |   INT|   |   文章編號|
|1|   TITLE|   |   |   NVARCHAR(24)|   |   文章編號|
|3|   CHIP_NO|   |   |   VARCHAR(15)|   |   晶片號碼|
|4|   ANIMAL_KIND|   |   |   VARCHAR(16)|   |   動物類別|
|5|   ANIMAL_SEX|   |   |   CHAR(1)|   |   動物性別|
|6|   ANIMAL_BREED|   |   |   VARCHAR(16)|   |   動物品種|
|6|   AREA_ID|   |   |   INT|   |   動物品種|
|7|   REASON|   |   |   NVARCHAR(72)|   |   送養原因|
|8|   POST_TYPE|   |   |   INT|   |   文章類型(1=送養、2=走失)|
|9|   MEMO|   |   |   NVARCHAR(108)|   |   備註|
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 寵物照片資料表
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|10|   POST_ID|   |   |   INT|   |   |
|10|   SEQ|   |   |   INT|   |   |
|10|   IMAGE_ADDRESS|   |   |   VARCHAR(47)|   |   |
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|


## 動物資料表 ANIMAL
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|10|   |   |   |   |   |   |
|10|   ANIMAL_KIND|   |   |   |   |   動物類別|
|10|   |   |   |   |   |   動物品種|
|10|   |   |   |   |   |   寵物照片檔名|
|10|   |   |   |   |   |   寵物照片檔名|
|10|   |   |   |   |   |   寵物照片檔名|
|10|   |   |   |   |   |   寵物照片檔名|


## 系統參數表 SYS_PARAM
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   SET_TYPE|   |   |   VARCHAR(20)|   |   系統代碼|
|2|   SET_ITEM|   |   |   VARCHAR(20)|   |   系統參數|
|3|   PARAM_VALUE|   |   |   NVARCHAR(28)|   |   數值|
|4|   PARAM_DESC|   |   |   NVARCHAR(36)|   |   描述|
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 留言資料表 GUESTBOOK
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   GUESTBOOK_ID|   |   |   INT|   |   留言流水號|
|2|   GUESTBOOK_MSG|   |   |   NVARCHAR(120)|   |   留言建立人員|
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 縣市資料表 CITY
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   CITY_ID|   |   |   INT|   |   |
|2|   CITY_NAME|   |   |   NVARCHAR(4)|   |   |
|11|   CITY_ENG_NAME|   |   |   VARCHAR(30)|   |   |

## 鄉鎮市區資料表 AREA
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   AREA_ID|   |   |   INT|   |   |
|2|   CITY_ID|   |   |   INT|   |   |
|11|   ZIP_CODE|   |   |   VARCHAR(3)|   |   |
|12|   AREA_NAME|   |   |  NVARCHAR(4)|   |   |
|13|   AREA_ENG_NAME|   |   |   NVARCHAR(30)|   |   |

## 收容所資料表 SHELTER
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   animal_shelter_pkid|   |   |   INT|   |   |
|2|   shelter_name|   |   |   NVARCHAR(50)|   |   |

## 動物品種資料表 ANIMAL_BREED
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   ANIMAL_BREED_ID|   |   |   INT|   |   |
|2|   ANIMAL_KIND|   |   |   NVARCHAR(16)|   |   |
|11|   ANIMAL_BREED_NAME|   |   |    NVARCHAR(10)|   |  |
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

尚需改善或學習的部分





此專案的參考資料


