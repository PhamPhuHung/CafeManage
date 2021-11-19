CREATE DATABASE CafeManage
GO

USE CAFEMANAGE
GO

------------------------------------------------------------------------------
-- TABLE CREATION
------------------------------------------------------------------------------
CREATE TABLE UserAccount
(
	ID INT IDENTITY(1000000,1) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL,
	Password NVARCHAR(1000) NOT NULL DEFAULT '20720532132149213101239102231223249249135100218',
	Status NVARCHAR(50) NOT NULL DEFAULT N'Đang làm', -- đang làm, đã nghỉ việc
	Salary INT,
	Type NVARCHAR(100) NOT NULL DEFAULT N'Nhân viên'
)
GO

CREATE TABLE CustomerAccount
(
	PhoneNum VARCHAR(100) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Address NVARCHAR(1000),
	LastBuyDate DATE DEFAULT GETDATE() NOT NULL,
	BonusPoint INT DEFAULT 0 NOT NULL
)
GO

CREATE TABLE TableFood
(
	ID INT IDENTITY(0,1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa đặt tên',
	Status NVARCHAR(100) NOT NULL DEFAULT N'Trống', -- Trống / Có người
	CurrentUsed NVARCHAR(100) NOT NULL DEFAULT N'Khả dụng' -- Khả dụng / Không khả dụng
)
GO

CREATE TABLE Food
(
	ID INT IDENTITY(0,1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL DEFAULT N'Món chưa đặt tên',
	Price INT NOT NULL DEFAULT 0,
	Category NVARCHAR(100) NOT NULL DEFAULT N'Khác',
	CurrentUsed NVARCHAR(100) NOT NULL DEFAULT N'Khả dụng' -- Khả dụng / Không khả dụng
)
GO 

CREATE TABLE Ingredient
(
	ID INT IDENTITY(0,1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Price INT NOT NULL DEFAULT 0,
	Unit NVARCHAR(100) NOT NULL,
	Amount FLOAT NOT NULL DEFAULT 0,
	ALarmAmount INT NOT NULL DEFAULT 10,
	CurrentUsed NVARCHAR(100) NOT NULL DEFAULT N'Khả dụng' -- Khả dụng / Không khả dụng
)
GO
SELECT * FROM INGREDIENT

CREATE TABLE IngredientInfo
(
	IDFood INT NOT NULL,
	IDIngredient INT NOT NULL,
	Amount FLOAT DEFAULT 0 NOT NULL,

	CONSTRAINT II_PK PRIMARY KEY(IDFood, IDIngredient),
	CONSTRAINT II_FK1 FOREIGN KEY(IDFood) REFERENCES DBO.Food(ID),
	CONSTRAINT II_FK2 FOREIGN KEY(IDIngredient) REFERENCES DBO.Ingredient(ID)

)
GO

CREATE TABLE TimeKeeping
(
	Date DATE DEFAULT GETDATE() NOT NULL,
	IDAccount INT NOT NULL,
	InTime TIME,
	OutTime TIME,
	SubtractHour INT DEFAULT 0 NOT NULL,
	Status INT DEFAULT 0 NOT NULL,

	CONSTRAINT TK_PK PRIMARY KEY(Date, IDAccount),
	CONSTRAINT TK_FK FOREIGN KEY(IDAccount) REFERENCES DBO.UserAccount(ID)
)
GO

CREATE TABLE Bill
(
	ID INT IDENTITY(0,1) PRIMARY KEY,
	Date Time DEFAULT GETDATE() NOT NULL,
	Discount INT DEFAULT 0 NOT NULL,
	FinalPrice INT DEFAULT 0 NOT NULL,
	Status NVARCHAR(100) DEFAULT N'Chưa thanh toán' NOT NULL,

	IDAccount INT NOT NULL,
	IDCustomer VARCHAR(100),
	IDTable INT NOT NULL,

	CONSTRAINT B_FK1 FOREIGN KEY(IDAccount) REFERENCES DBO.UserAccount(ID),
	CONSTRAINT B_FK2 FOREIGN KEY(IDCustomer) REFERENCES DBO.CustomerAccount(PhoneNum),
	CONSTRAINT B_FK3 FOREIGN KEY(IDTable) REFERENCES DBO.TableFood(ID)
)
GO

CREATE TABLE BillInfo
(
	IDFood INT NOT NULL,
	IDBill INT NOT NULL,
	Amount INT NOT NULL DEFAULT 0,
	TotalPrice INT NOT NULL DEFAULT 0,

	CONSTRAINT BI_PK PRIMARY KEY(IDFood, IDBill),
	CONSTRAINT BI_FK1 FOREIGN KEY(IDFood) REFERENCES DBO.Food(ID),
	CONSTRAINT BI_FK2 FOREIGN KEY(IDBill) REFERENCES DBO.Bill(ID)
)
GO

CREATE TABLE BillImport
(
	ID INT IDENTITY(0,1) PRIMARY KEY,
	Date Time DEFAULT GETDATE() NOT NULL,
	Discount INT NOT NULL DEFAULT 0,
	FinalPrice INT DEFAULT 0 NOT NULL,
	Status NVARCHAR(100) DEFAULT N'Chưa thanh toán' NOT NULL,

	IDUser INT NOT NULL,
	CONSTRAINT BIM_FK FOREIGN KEY(IDUser) REFERENCES DBO.UserAccount(ID)
)
GO

CREATE TABLE BillImportInfo
(
	IDBillIm INT NOT NULL,
	IDIngredient INT NOT NULL,
	Amount INT NOT NULL, 
	TotalPrice INT NOT NULL,

	CONSTRAINT BIMI_FK1 FOREIGN KEY(IDBillIm) REFERENCES DBO.BillImport(ID),
	CONSTRAINT BIMI_FK2 FOREIGN KEY(IDIngredient) REFERENCES DBO.Ingredient(ID)
)
GO
select * from billimport
select * from billimportinfo
------------------------------------------------------------------------------
-- DATABASE CREATION
------------------------------------------------------------------------------
INSERT DBO.UserAccount(DisplayName, Type) VALUES(N'Phạm Phú Hưng', N'Quản Lý')
INSERT DBO.UserAccount(DisplayName, Type) VALUES(N'Nguyễn Thị Mỹ Linh', N'Quản Lý')
INSERT DBO.UserAccount(DisplayName, Salary) VALUES(N'Trần Văn Châu', 6000000)
INSERT DBO.UserAccount(DisplayName, Salary) VALUES(N'Nguyễn Gia Bảo', 8000000)
GO

INSERT DBO.CustomerAccount(PhoneNum, Name) VALUES('0914505395', N'Lý Gia Linh')
INSERT DBO.CustomerAccount(PhoneNum, Name) VALUES('0932741023', N'Nguyễn Quốc Mỹ')
INSERT DBO.CustomerAccount(PhoneNum, Name) VALUES('0277087416', N'Đỗ Đạt Minh')
INSERT DBO.CustomerAccount(PhoneNum, Name) VALUES('0904161014', N'Nguyễn Trần Quốc Duy')
INSERT DBO.CustomerAccount(PhoneNum, Name) VALUES('0789857186', N'Nguyễn Thị Mỹ Xuyên')
INSERT DBO.CustomerAccount(PhoneNum, Name) VALUES('0917084701', N'Trần Thị Tú ANh')
GO

DECLARE @i INT = 1
WHILE @i<=10
BEGIN
	INSERT DBO.TableFood(Name) VALUES(N'Bàn ' + CAST(@i AS NVARCHAR(5)))
	SET @i = @i + 1
END
GO
DECLARE @i INT = 1
WHILE @i<=3
BEGIN
	INSERT DBO.TableFood(Name) VALUES(N'Bàn VIP' + CAST(@i AS NVARCHAR(5)))
	SET @i = @i + 1
END
GO

INSERT DBO.Food(Name, Category, Price) VALUES(N'Tôm tích nướng mỡ hành', N'Tôm', 180000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Tôm sú lăn bột', N'Tôm', 165000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Tôm càng xanh hấp', N'Tôm', 850000)

INSERT DBO.Food(Name, Category, Price) VALUES(N'Cua nhồi thịt', N'Cua', 199000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Cua chiên bơ', N'Cua', 389000)

INSERT DBO.Food(Name, Category, Price) VALUES(N'Vi Cá mập', N'Cá', 679000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Cá lóc nướng trui', N'Cá', 99000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Chả cá basa hấp', N'Cá', 120000)

INSERT DBO.Food(Name, Category, Price) VALUES(N'Lòng lơn nướn', N'Thịt', 85000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Đùi lợn chiên giòn', N'Thịt', 85000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Bò bít tết', N'Thịt', 125000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Cánh gà chiên nướng mắm', N'Thịt', 85000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Đùi gà lăn bột', N'Thịt', 85000)

INSERT DBO.Food(Name, Category, Price) VALUES(N'Lẩu chua cay', N'Lẩu', 250000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Lẩu hải sản', N'Lẩu', 250000)

INSERT DBO.Food(Name, Category, Price) VALUES(N'Bia tươi', N'Giải khát', 22000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Cocacola', N'Giải khát', 18000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Pepsi', N'Giải khát', 18000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Cà phê sữa đá', N'Giải khát', 22000)
INSERT DBO.Food(Name, Category, Price) VALUES(N'Nước ép', N'Giải khát', 22000)
GO 

INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Thịt lơn', 180000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Thịt Bò', 350000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Thịt Gà', 120000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Tôm', 380000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Cua', 400000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Cá', 250000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Rau', 50000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Bột', 20000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Bia', 8000, N'Lon', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Cocacola', 5000, N'Lon', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Pepsi', 5000, N'Lon', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Cà phê',120000, N'Kg', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Sữa bò',60000, N'Lít', 2000)
INSERT DBO.Ingredient(Name, Price, Unit, Amount) VALUES(N'Trái cây',50000, N'Kg', 2000)
GO

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(0, 3, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(0, 6, 0.05)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(1, 3, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(1, 7, 0.05)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(2, 3, 0.2)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(3, 4, 0.1)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(3, 0, 0.4)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(4, 4, 0.5)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(4, 5, 0.4)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(5, 5, 0.5)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(6, 5, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(6, 6, 1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(7, 5, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(7, 7, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(7, 6, 0.1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(8, 0, 0.2)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(9, 0, 0.2)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(10, 1, 0.2)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(11, 2, 0.2)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(12, 2, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(12, 7, 0.1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(13, 0, 0.5)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(13, 6, 1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(14, 3, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(14, 4, 0.1)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(14, 5, 0.2)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(14, 6, 1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(15, 8, 1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(16, 9, 1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(17, 10, 1)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(18, 11, 0.1)
INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(18, 12, 0.2)

INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) VALUES(19, 13, 0.2)
GO

------------------------------------------------------------------------------
-- STORED PROCEDURE CREATION
------------------------------------------------------------------------------
CREATE PROC UP_LogIn
@ID INT, @password NVARCHAR(1000)
AS SELECT * FROM DBO.UserAccount WHERE @ID = ID AND @password = password
GO
EXEC UP_LogIn @ID = 1000000, @password = 0
GO

CREATE PROC UP_GetAccountByID
@ID INT
AS SELECT * FROM DBO.UserAccount WHERE @ID = ID
GO
EXEC UP_GetAccountByID @ID = 1000000
GO

CREATE PROC UP_GetListUser
AS SELECT ID, DisplayName, Status, Salary, Type FROM DBO.UserAccount
GO

CREATE PROC UP_AddNewUser
@displayName NVARCHAR(100), @salary INT, @type NVARCHAR(100)
AS INSERT DBO.UserAccount(DisplayName, Salary, Type) VALUES(@displayName, @salary, @type)
GO

CREATE PROC UP_ModifyUser
@ID INT, @displayName NVARCHAR(100), @status NVARCHAR(100), @salary INT, @type NVARCHAR(100)
AS UPDATE DBO.UserAccount SET DisplayName = @displayName, Status = @status, Salary = @salary, type = @type WHERE ID = @ID
GO

CREATE PROC UP_ResetUserPass
@ID INT
AS UPDATE DBO.UserAccount SET Password = '20720532132149213101239102231223249249135100218' WHERE ID = @ID
GO


CREATE PROC UP_DeleteUser
@ID INT
AS BEGIN
	DELETE DBO.UserAccount WHERE ID = @ID
	IF @@ROWCOUNT <= 0
	UPDATE DBO.UserAccount SET Status = N'Đã nghỉ' WHERE ID = @ID
	END
GO

CREATE PROC UP_AccountUpdate
@ID INT, @DisplayName NVARCHAR(100), @pass NVARCHAR(1000), @newPass NVARCHAR(1000)
AS BEGIN
		IF @newPass = NULL OR @newPass = '2122914021714301784233128915223624866126'
			UPDATE DBO.UserAccount SET DisplayName = @DisplayName WHERE id = @ID AND Password = @pass
		ELSE UPDATE DBO.UserAccount SET DisplayName = @DisplayName, Password = @newPass WHERE id = @ID AND Password = @pass
	END
GO

CREATE PROC UP_GetListTable
AS SELECT * FROM DBO.TableFood
GO
EXEC UP_GetListTable
GO 

CREATE PROC UP_AddTable
@name NVARCHAR(100)
AS INSERT DBO.TableFood(Name) VALUES(@name)
GO

CREATE PROC UP_ModifyTable
@ID INT, @name NVARCHAR(100)
AS UPDATE DBO.TableFood SET Name = @name WHERE ID = @ID
GO

CREATE PROC UP_DeleteTable
@ID INT
AS BEGIN
	DELETE DBO.Food WHERE ID = @ID
	IF(@@ROWCOUNT <= 0)
	UPDATE DBO.TableFood SET CurrentUsed = N'Không khả dụng' WHERE ID = @ID
	END
GO

CREATE PROC UP_GetListFoodCategory
AS SELECT DISTINCT(Category) FROM DBO.FOOD WHERE CurrentUsed = N'Khả dụng'
GO

CREATE PROC UP_GetListFood
AS SELECT * FROM DBO.Food
GO

CREATE PROC UP_AddFood
@name NVARCHAR(100), @category NVARCHAR(100), @price INT
AS INSERT DBO.Food(Name, Category, Price) VALUES(@name, @category, @price)
GO

CREATE PROC UP_ModifyFood
@ID INT, @Name NVARCHAR(100), @price INT, @category NVARCHAR(100)
AS UPDATE DBO.Food SET Name = @name, Price = @price, Category = @category WHERE ID = @ID
GO

CREATE PROC UP_DeleteFood
@ID INT
AS BEGIN 
	DELETE DBO.Food WHERE ID = @ID
	IF(@@ROWCOUNT <=0 ) UPDATE DBO.Food SET CurrentUsed = N'Không khả dụng' WHERE ID = @ID
END
GO

CREATE PROC UP_GetListFood_ByCategory
@Category NVARCHAR(100)
AS BEGIN
	IF @Category = NULL OR @Category = ''
	SELECT ID, Name as N'Tên món', Price as N'Đơn giá' FROM DBO.Food WHERE CurrentUsed = N'Khả dụng'
	ELSE
	SELECT ID, Name as N'Tên món', Price as N'Đơn giá' FROM DBO.Food WHERE Category = @Category AND CurrentUsed = N'Khả dụng'
END
GO

CREATE PROC UP_GetListIngredient
AS SELECT * FROM DBO.Ingredient
GO

CREATE PROC UP_AddIngredient
@name NVARCHAR(100), @price INT, @unit NVARCHAR(100), @alarmAmount INT
AS INSERT DBO.Ingredient(Name, Price, Unit, ALarmAmount) VALUES(@name, @price, @unit, @alarmAmount)
GO

CREATE PROC UP_ModifyIngredient
@ID INT, @name NVARCHAR(100), @price INT, @unit NVARCHAR(100), @amount INT, @alarmAmount INT
AS UPDATE DBO.Ingredient SET Name = @name, Price = @price, Unit = @unit, Amount = @amount, AlarmAMount = @alarmAmount WHERE ID = @ID
GO

CREATE PROC UP_DeleteIngredient
@ID INT
AS BEGIN 
	DELETE DBO.Ingredient WHERE ID = @ID
	IF(@@ROWCOUNT <= 0)
	UPDATE DBO.Ingredient SET CurrentUsed = N'Không khả dụng' WHERE ID = @ID
END
GO

CREATE PROC UP_GetListCustomer
AS SELECT * FROM DBO.CustomerAccount
GO

CREATE PROC UP_GetCustomerAccount_ByPhoneNum
@PhoneNum NVARCHAR(100)
AS SELECT * FROM DBO.CustomerAccount WHERE PhoneNum = @PhoneNum
GO

CREATE PROC UP_EnrollNewCustomer
@PhoneNum NVARCHAR(100), @Name NVARCHAR(100), @address NVARCHAR(100)
AS BEGIN
	INSERT DBO.CustomerAccount(PhoneNum, Name, Address)
	VALUES(@PhoneNum, @Name, @address)
END
GO

CREATE PROC UP_CustomerInfoModify
@PhoneNum NVARCHAR(100), @Name NVARCHAR(100), @address NVARCHAR(100)
AS BEGIN
	UPDATE DBO.CustomerAccount 
	SET Name = @Name, Address = @address
	WHERE PhoneNum = @PhoneNum
END
GO

CREATE PROC UP_GetUncheckedBill_ByTableID
@idTable INT
AS SELECT * FROM DBO.Bill WHERE IDTable = @idTable AND Status = N'Chưa thanh toán'
GO

CREATE PROC UP_GetListMenu_ByIDBill
@idBill INT
AS BEGIN
	SELECT F.Name, F.Price, BI.Amount, (F.Price * BI.Amount) AS 'TotalPrice'
	FROM DBO.BillInfo AS BI
	JOIN DBO.Food AS F ON BI.IDFood = F.ID
	JOIN DBO.Bill AS B ON B.ID = BI.IDBill
	WHERE B.ID = @idBill
END
GO

CREATE PROC UP_InsertBill
@idUser INT , @idTable INT
AS INSERT DBO.Bill(IDAccount, IDTable) VALUES(@idUser, @idTable)
GO

CREATE PROC UP_InsertBillInfo
@idFood INT, @idBill INT, @amount INT
AS BEGIN
	DECLARE @check INT = 0
	SELECT @check = COUNT(*) FROM DBO.BillInfo WHERE IDFood = @idFood AND IDBill = @idBill

	IF(@check = 0 AND @amount > 0) INSERT DBO.BillInfo(IDFood, IDBill, Amount)VALUES(@idFood, @idBill, @amount)
	ELSE BEGIN
		DECLARE @count INT = 0
		SELECT @count = Amount FROM DBO.BillInfo WHERE IDFood = @idFood AND IDBill = @idBill
		SET @count = @count + @amount

		IF(@count <= 0) DELETE DBO.BillInfo WHERE IDFood = @idFood AND IDBill = @idBill
		ELSE UPDATE DBO.BillInfo SET Amount = @count WHERE IDFood = @idFood AND IDBill = @idBill
	END
END
GO

CREATE PROC UP_DeleteBillInfo
@idFood INT, @idBill INT
AS DELETE DBO.BillInfo WHERE IDFood = @idFood AND IDBill = @idBill
GO

CREATE PROC UP_GetIngredientInfoList_byIDFood
@idFood INT
AS SELECT * FROM DBO.IngredientInfo WHERE IDFood = @IDFood
GO

CREATE PROC UP_ModifyIngredientAMount
@idIngredient INT, @amount FLOAT
AS BEGIN
	DECLARE @currentAmount FLOAT
	SELECT @currentAmount = Amount FROM DBO.Ingredient WHERE ID = @idIngredient
	SET @amount = @currentAmount + @amount
	IF @amount >= 0
	UPDATE DBO.Ingredient SET Amount = @amount WHERE ID = @idIngredient
END
GO

CREATE PROC UP_GetIngredient_ByID
@id INT
AS BEGIN
	SELECT * FROM DBO.Ingredient WHERE id = @id
END
GO

CREATE PROC UP_GetIngredientInfoList_ByIDFood_Advance
@idFood INT
AS BEGIN
	SELECT I.ID, I.Name as N'Tên nguyên liệu', I.Price AS N'Đơn giá', I.Unit AS N'Đơn vị', II.Amount AS N'Số lượng'
	FROM DBO.IngredientInfo AS II
	JOIN DBO.Ingredient AS I ON II.IDIngredient = I.ID
	JOIN DBO.Food AS F ON II.IDFood = F.ID
	WHERE F.ID = @idFood
END
GO

CREATE PROC UP_DeleteIngredientInfoList
@idFood INT
AS DELETE DBO.IngredientInfo WHERE IDFood = @idFood
GO

CREATE PROC UP_AddIngredientInfo
@idFood INT, @idIngredient INT, @amount FLOAT
AS BEGIN
	INSERT DBO.IngredientInfo(IDFood, IDIngredient, Amount) 
	VALUES(@idFood, @idIngredient, @amount)
END
GO

ALTER PROC UP_GetTopIDFood
AS SELECT TOP 1 ID FROM DBO.Food ORDER BY ID DESC
GO

select * from ingredient

CREATE PROC UP_GetListIngredient
AS SELECT * FROM DBO.Ingredient
GO

CREATE PROC UP_AddCustomerToBill
@phoneNum VARCHAR(100), @idBill INT
AS UPDATE DBO.Bill SET IDCustomer = @phoneNum WHERE ID = @idBill
GO

CREATE PROC UP_CustomerUseBonusForBill
@phoneNum VARCHAR(100), @idBill INT, @disCount INT
AS UPDATE DBO.Bill SET Discount = @disCount WHERE ID = @idBill AND IDCustomer = @phoneNum
GO

CREATE PROC UP_CheckOut
@idBill INT, @finalPrice INT
AS BEGIN
	UPDATE DBO.Bill SET Status = N'Đã thanh toán', FinalPrice = @finalPrice 
	WHERE ID = @idBill AND Status = N'Chưa thanh toán'
END
GO

CREATE PROC UP_ModifyBonusPoint_AfterCheckOut
@used INT, @get INT, @phoneNum VARCHAR(100)
AS UPDATE DBO.CustomerAccount SET BonusPoint = BonusPoint - @used + @get, LastBuyDate = GETDATE() WHERE PhoneNum = @phoneNum
GO

CREATE PROC UP_InsertBillImport
@idUser INT
AS INSERT DBO.BillImport(IDUser) VALUES(@idUser)
GO

CREATE PROC UP_Insert_BillImportInfo
@IDBillIm INT, @IDIngredient INT, @Amount INT, @TotalPrice INT
AS BEGIN
	INSERT DBO.BillImportInfo(IDBillIm, IDIngredient, Amount, TotalPrice) 
	VALUES(@IDBillIm, @IDIngredient, @Amount, @TotalPrice)
END
GO

CREATE PROC UP_GetUncheckedBillImport
AS SELECT * FROM DBO.BillImport WHERE Status = N'Chưa thanh toán'
GO

CREATE PROC UP_BillImportCheckOut
@id INT, @finalPrice INT, @discount INT
AS UPDATE DBO.BillImport SET Status = N'Đã thanh toán', FinalPrice = @finalPrice, Discount = @discount WHERE ID = @id
GO

CREATE PROC UP_GetTimeKeepingToday_byID
@ID INT
AS BEGIN
	DECLARE @date DATE = GETDATE()
	SELECT * FROM DBO.TimeKeeping WHERE IDAccount = @ID AND Date = @date
END
GO


CREATE PROC UP_TimeKeepingTodayCheck_ByID
@ID INT, @Time TIME
AS BEGIN
	DECLARE @date DATE = GETDATE()
	IF NOT EXISTS(SELECT * FROM DBO.TimeKeeping	WHERE Date = @date AND IDAccount = @ID)
		INSERT DBO.TimeKeeping(IDAccount) VALUES(@ID)

	DECLARE @check INT
	SELECT @check = Status FROM DBO.TimeKeeping WHERE Date = @date AND IDAccount = @ID
	IF @check = 0 
		UPDATE DBO.TimeKeeping SET Status = 1, InTime = @time WHERE DATE = @date and IDAccount = @ID
	ELSE UPDATE DBO.TimeKeeping SET OutTime = @time WHERE DATE = @date and IDAccount = @ID
END
GO

CREATE PROC UP_GetListTimeKeeping_ByID
@ID INT
AS SELECT Date, InTime, OutTime, SubtractHour FROM DBO.TimeKeeping WHERE IDAccount = @ID
GO

exec UP_TimeKeepingTodayCheck @id = 1000000, @time = '20201212'

SELECT * FROM USERACCOUNT

select * from timekeeping

SELECT * FROM DBO.TimeKeeping	WHERE Date = GETDATE() AND IDAccount = 1000000

SELECT * FROM DBO.TimeKeeping	WHERE Date = '20210205'

SELECT * FROM DBO.TimeKeeping	WHERe IDAccount = 1000000

INSERT DBO.TimeKeeping(IDAccount) VALUES(1000000)
delete timekeeping

GO

CREATE PROC UP_TimeKeepingAdd_byIDandDate
@id INT, @date DATE, @inTime TIME, @outTime TIME, @subtractHour INT
AS INSERT DBO.TimeKeeping(IDAccount, Date, InTime, OutTime, SubTractHour ) VALUES(@id, @date, @inTime, @outTime, @subTractHour)
GO

CREATE PROC UP_TimeKeepingModify_byIDandDate
@id INT, @date DATE, @inTime TIME, @outTime TIME, @subtractHour INT
AS UPDATE DBO.TimeKeeping SET IDAccount = @id, Date = @date, InTime = @inTime, OutTime = @outTime, SubTractHour = @subTractHour WHERE IDAccount = @id AND Date = @date
GO

EXEC UP_TimeKeepingModify_byIDandDate
@id = 1000000, @date = '20210205', @inTime = '20210205', @outTime  = '20210205', @subtractHour = 100
GO

SELECT * FROM TIMEKEEPING
CREATE TRIGGER UT_BillCheckOut
ON DBO.Bill FOR UPDATE
AS BEGIN
	DECLARE @check INT = 0
	SELECT @check = COUNT(*) FROM Inserted WHERE Status = N'Đã thanh toán'

	DECLARE @idTable INT = 0
	SELECT @idTable = Inserted.IDTable FROM Inserted WHERE Status = N'Đã thanh toán'

	IF @check > 0 UPDATE DBO.TableFood SET Status = N'Trống' WHERE ID = @idTable
END
GO

CREATE TRIGGER UT_InsertBill
ON DBO.Bill FOR INSERT
AS BEGIN
	DECLARE @check INT = 0
	SELECT @check = COUNT(*) FROM Inserted WHERE Status = N'Chưa thanh toán'

	DECLARE @idTable INT = 0
	SELECT @idTable = Inserted.IDTable FROM Inserted WHERE Status = N'Chưa thanh toán'

	IF @check > 0 UPDATE DBO.TableFood SET Status = N'Có người' WHERE ID = @idTable
END
GO

CREATE TRIGGER UT_DeleteBillInfo
ON DBO.BillInfo FOR DELETE
AS BEGIN
	DECLARE @count INT  = 0
	DECLARE @idBill INT = 0

	SELECT @count = COUNT(*) FROM DBO.BillInfo	
	JOIN DBO.Bill ON ID = IDBill

	SELECT @idBill = idBill FROM Deleted

	IF @count = 0 DELETE DBO.Bill WHERE ID = @idBill
END
GO

CREATE TRIGGER UT_DeleteBill
ON DBO.Bill FOR DELETE
AS BEGIN
	Declare @idTable INT
	SELECT @idTable = IDTable FROM Deleted

	UPDATE DBO.TableFood SET Status = N'Trống' WHERE ID = @idTable
END
GO

--select * from bill
--update bill set status = N'Đã tha
--nh toán' where id = 4
--select * from tablefood
--DROP TRIGGER UT_bILLCHECKOUT
----CREATE TRIGGER UT_CustomerCheckOut
----ON DBO.Bill FOR UPDATE
----AS BEGIN
----	DECLARE @check INT = 0
----	SELECT @check = COUNT(*) FROM Inserted
----	IF @check = 0 ROLLBACK UP_CheckOut -- I still stuck here because I don't know how to do

----END
----GO
--SELECT * FROM BILL
--SELECT * FROM DBO.UserAccount
--SELECT * FROM DBO.CustomerAccount
--SELECT * FROM DBO.TableFood
--SELECT * FROM DBO.Food
--SELECT * FROM DBO.Ingredient
--SELECT * FROM DBO.IngredientInfo JOIN DBO.Food ON IDFood = ID AND Name = N'Lẩu hải sản'
--SELECT * FROM DBO.Bill
--SELECT * FROM DBO.BillInfo
--EXEC UP_InsertBill @idUser =1000000 , @idTable =1

--DELETE BILLINFO
--DELETE BILL

--INSERT DBO.Bill(IDAccount, IDTable)VALUES(1000000, 2)
--INSERT DBO.Bill(IDAccount, IDTable)VALUES(1000000, 5)
--INSERT DBO.Bill(IDAccount, IDTable)VALUES(1000000, 9)

--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(2, 0, 5)
--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(5, 0, 5)
--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(6, 0, 5)
--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(2, 1, 8)
--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(1, 1, 8)
--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(3, 1,8)
--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(10, 2, 1)
--INSERT DBO.BillInfo(IDFood, IDBill, Amount) VALUES(12, 2,1)

--update ingredient set amount = 2000


select * from billimport
select * from billimportinfo