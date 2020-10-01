# 寵物領養平台 PET_ADOPTION_SYSTEM

###專案介紹



###動機
練習asp.net core mvc，前端大部分採用原生JS


###開發環境－asp.net core 3.1

###分層架構  
主專案－PET_ADOPTION_SYSTEM  
資料存取層－PET_ADOPTION_SYSTEM.Dacs  
資料模型層－PET_ADOPTION_SYSTEM.Models  
服務層－PET_ADOPTION_SYSTEM.Services  

寫入LOG套件－NLog  
ORM工具－Dapper  

後端套件管理Nuget  
前端套件管理libman.json  
新增前端套件流程－專案右鍵->加入->用戶端程式庫  

## 系統介紹



##頁面





# 資料庫Schema

## 會員資料表 MEMBER
|項目|欄位名稱|主外鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   ACCOUNT|   P|   N|   VARCHAR(16)|   |   會員編號|
|2|   PASSWARD|   |   N|   VARCHAR(24)|   |   密碼|
|2|   NAME|   |      N|   NVARCHAR(20)|   |姓名|
|3|   EMAIL|   |      N|   NVARCHAR(56)|   |聯絡信箱|
|4|   PHONE|   |      N|   VARCHAR(10)|   |連絡電話|
|4|   ROLE|   |      N|   CHAR(1)|   |使用者角色(1:'USER', 2:'ADMIN')|
|4|   DATA_STATE|   |   N|   CHAR(1)|   'N'|   狀態N ('N':'正常使用中', 'D':'已刪除', 'F' :'凍結中')|
|5|   CRT_USER|   |   Y|      VARCHAR(16)|   |建立人員|
|6|   CRT_DATE|   |   Y|      DATETIME|   GETDATE()|建立日期|
|7|   MDF_USER|   |   Y|      VARCHAR(16)|   |修改人員|
|8|   MDF_DATE|   |   Y|      DATETIME|   GETDATE()|修改日期|

## 寵物文章資料表(送養或走失)
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   POST_ID|   P|   |   INT|   |   文章編號|
|1|   TITLE|   |   |   NVARCHAR(24)|   |   文章編號|
|3|   CHIP_NO|   |   |   VARCHAR(15)|   |   晶片號碼(長度為10~15)|
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
|10|   POST_ID|   |   |   INT|   |   流水號|
|10|   SEQ|   |   |   INT|   |   順序|
|10|   IMAGE_ADDRESS|   |   |   VARCHAR(47)|   |   照片的相對位址|
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

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
|1|   CITY_ID|   |   |   INT|   |   流水號|
|2|   CITY_NAME|   |   |   NVARCHAR(4)|   |   台灣縣市名|
|11|   CITY_ENG_NAME|   |   |   VARCHAR(30)|   |   台灣縣市英文名|

## 鄉鎮市區資料表 AREA
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   AREA_ID|   P|   |   INT|   |   流水號|
|2|   CITY_ID|   F|   |   INT|   |   縣市資料表流水號|
|11|   ZIP_CODE|   |   |   VARCHAR(3)|   |   郵遞區號|
|12|   AREA_NAME|   |   |  NVARCHAR(4)|   |   鄉鎮市區中文名|
|13|   AREA_ENG_NAME|   |   |   NVARCHAR(30)|   |   鄉鎮市區英文名|

## 收容所資料表 SHELTER
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   animal_shelter_pkid|   |   |   INT|   |   收容所流水號|
|2|   shelter_name|   |   |   NVARCHAR(50)|   |   收容所名稱|

## 動物品種資料表 ANIMAL_BREED
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   ANIMAL_BREED_ID|   P|   |   INT|   |   流水號|
|2|   ANIMAL_KIND|   F|   |   NVARCHAR(16)|   |   動物類別|
|11|   ANIMAL_BREED_NAME|   |   |    NVARCHAR(10)|   |  動物品種名稱|
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 公告資料表 ANNOUNCEMENT
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   ANNOUNCE_ID|   P|   |   INT|   |   流水號|
|2|   TITLE|   |   |   NVARCHAR(24)|   |   標題|
|11|   CONTENT|   |   |    NVARCHAR(144)|   |  內容|
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

尚需改善或學習的部分
1. 後端非同步的使用 async await  
2. 前端資料模型驗證可改用非套件或更輕量化的套件





此專案的參考資料


