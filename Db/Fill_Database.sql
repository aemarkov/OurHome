USE OurHome

SET @CityId = (SELECT Id FROM Cities WHERE CityName='Волгоград')
SET @UserId = (SELECT Id FROM AbpUsers where UserName = 'user')
SET @ColdWaterResourceId = (SELECT ID FROM ResourceTypes WHERE Value = 'COLD_WATER')

-- Создать города
if not EXISTS (SELECT Id FROM Cities WHERE CityName='Волгоград')
  INSERT INTO Cities (CityName) VALUES ('Волгоград')

-- Создать пользователей
IF not EXISTS (SELECT Id FROM Customers c WHERE Id = @UserId)
  INSERT INTO Customers (ID, CityId, Street, Building, Flat, IsDeleted, CreationTime) VALUES (
    @UserId, @CityId,
    'ул. Ленина', '5a', '47',
    0, GETDATE ()  )


-- Создать регистаторы
IF not EXISTS (SELECT Id FROM Registrators r WHERE r.CustomerId = @UserID AND r.ResourceId = @ColdWaterResourceId)
  INSERT INTO Registrators (CustomerId, ResourceId, IsDeleted, CreationTime) 
  VALUES (@UserId, @ColdWaterResourceId, 0, GETDATE())

