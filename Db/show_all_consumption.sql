USE OurHome

SELECT r.CustomerId, rc.RegistratorId, rc.CreationTime, rc.Consumption, rt.DisplayText, rt.Unit FROM Registrators r
  JOIN ResourceConsumptions rc on rc.RegistratorId = r.Id
  JOIN ResourceTypes rt ON r.ResourceId = rt.Id