# 寵物領養平台 PET_ADOPTION_SYSTEM

### 專案介紹



### 動機
練習asp.net core mvc，前端大部分採用原生JS

### 開發環境
asp.net core 3.1  
IDE－Visual studio 2019、Visual studio code(前端畫面設計)
DB－SQL Server

### 分層架構  
主專案－PET_ADOPTION_SYSTEM  
資料存取層－PET_ADOPTION_SYSTEM.Dacs  
資料模型層－PET_ADOPTION_SYSTEM.Models  
服務層－PET_ADOPTION_SYSTEM.Services  

寫入LOG套件－NLog  
ORM工具－Dapper  

後端套件管理Nuget  
前端套件管理libman.json  
新增前端套件流程－專案右鍵->加入->用戶端程式庫  

## 頁面
1. 首頁
1. 寵物領養
1. 寵物協尋
1. 發表文章
1. 留言板
1. 註冊會員
1. 登入會員
1. 我的文章
1. 寵物收容所資料
1. 後臺管理




# 資料庫Schema

## 會員資料表 MEMBER
|項目|欄位名稱|主外鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   ACCOUNT|   P|   N|   VARCHAR(16)|   |   會員編號|
|2|   PASSWARD|   |   N|   VARCHAR(24)|   |   密碼|
|3|   NAME|   |      N|   NVARCHAR(20)|   |姓名|
|4|   EMAIL|   |      N|   NVARCHAR(56)|   |聯絡信箱|
|5|   PHONE|   |      N|   VARCHAR(10)|   |連絡電話|
|6|   ROLE|   |      N|   CHAR(1)|   |使用者角色(1:'USER', 2:'ADMIN')|
|7|   DATA_STATE|   |   N|   CHAR(1)|   'N'|   狀態N ('N':'正常使用中', 'D':'已刪除', 'F' :'凍結中')|
|8|   CRT_USER|   |   Y|      VARCHAR(16)|   |建立人員|
|9|   CRT_DATE|   |   Y|      DATETIME|   GETDATE()|建立日期|
|10|   MDF_USER|   |   Y|      VARCHAR(16)|   |修改人員|
|11|   MDF_DATE|   |   Y|      DATETIME|   GETDATE()|修改日期|

## 寵物文章資料表(送養或走失)
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   POST_ID|   P|   |   INT|   |   文章編號|
|2|   TITLE|   |   |   NVARCHAR(24)|   |   文章編號|
|3|   CHIP_NO|   |   |   VARCHAR(15)|   |   晶片號碼(長度為10~15)|
|4|   ANIMAL_KIND|   |   |   VARCHAR(16)|   |   動物類別|
|5|   ANIMAL_SEX|   |   |   CHAR(1)|   |   動物性別|
|6|   ANIMAL_BREED|   |   |   VARCHAR(16)|   |   動物品種|
|7|   AREA_ID|   |   |   INT|   |   動物品種|
|8|   REASON|   |   |   NVARCHAR(72)|   |   送養原因|
|9|   POST_TYPE|   |   |   INT|   |   文章類型(1=送養、2=走失)|
|10|   MEMO|   |   |   NVARCHAR(108)|   |   備註|
|11|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|12|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|13|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|14|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|15|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 寵物照片資料表
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   POST_ID|   |   |   INT|   |   流水號|
|2|   SEQ|   |   |   INT|   |   順序|
|3|   IMAGE_ADDRESS|   |   |   VARCHAR(47)|   |   照片的相對位址|
|4|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|5|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|6|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|7|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|8|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 系統參數表 SYS_PARAM
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   SET_TYPE|   |   |   VARCHAR(20)|   |   系統代碼|
|2|   SET_ITEM|   |   |   VARCHAR(20)|   |   系統參數|
|3|   PARAM_VALUE|   |   |   NVARCHAR(28)|   |   數值|
|4|   PARAM_DESC|   |   |   NVARCHAR(36)|   |   描述|
|5|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|6|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|7|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|8|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|9|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 留言資料表 GUESTBOOK
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   GUESTBOOK_ID|   |   |   INT|   |   留言流水號|
|2|   GUESTBOOK_MSG|   |   |   NVARCHAR(120)|   |   留言建立人員|
|3|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|4|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|5|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|6|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|7|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 縣市資料表 CITY
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   CITY_ID|   |   |   INT|   |   流水號|
|2|   CITY_NAME|   |   |   NVARCHAR(4)|   |   台灣縣市名|
|3|   CITY_ENG_NAME|   |   |   VARCHAR(30)|   |   台灣縣市英文名|

## 鄉鎮市區資料表 AREA
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   AREA_ID|   P|   |   INT|   |   流水號|
|2|   CITY_ID|   F|   |   INT|   |   縣市資料表流水號|
|3|   ZIP_CODE|   |   |   VARCHAR(3)|   |   郵遞區號|
|4|   AREA_NAME|   |   |  NVARCHAR(4)|   |   鄉鎮市區中文名|
|5|   AREA_ENG_NAME|   |   |   NVARCHAR(30)|   |   鄉鎮市區英文名|

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
|3|   ANIMAL_BREED_NAME|   |   |    NVARCHAR(10)|   |  動物品種名稱|
|4|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|5|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|6|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|7|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|8|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

## 公告資料表 ANNOUNCEMENT
|項目|欄位名稱|主鍵|可NULL|資料型態|預設值|描述|
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|1|   ANNOUNCE_ID|   P|   |   INT|   |   流水號|
|2|   TITLE|   |   |   NVARCHAR(24)|   |   標題|
|3|   CONTENT|   |   |    NVARCHAR(144)|   |  內容|
|4|   DATA_STATE|   |   |   CHAR(1)|   'N'|   狀態|
|5|   CRT_USER|   |   |  VARCHAR(16)|   |   建立人員|
|6|   CRT_DATE|   |   |   DATETIME|   GETDATE()|   建立日期|
|7|   MDF_USER|   |   |   VARCHAR(16)|   |   修改人員|
|8|   MDF_DATE|   |   |   DATETIME|   GETDATE()|   修改日期|

### 尚需改善或學習的部分
1. 後端非同步的使用 async await  
https://www.huanlintalk.com/2016/01/async-and-await.html
2. 前端資料模型驗證可改用非套件或更輕量化的套件
3. bundleconfig in .net core https://dotblogs.com.tw/supershowwei/2017/07/26/164153
4. 後端Role的驗證
5. 資料存取層抽介面、泛型應用、Repository pattern、ConnectFactory(factory pattern)、Unit of Work
https://www.c-sharpcorner.com/article/dapper-and-repository-pattern-in-web-api/
https://kevintsengtw.blogspot.com/2015/04/aspnet-mvc-twmvc18.html


### 此專案的參考資料

寵物收容API串接
https://data.coa.gov.tw/Query/ServiceTransDetail.aspx?id=QcbUEzN6E6DL


