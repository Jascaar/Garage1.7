select
count(id) as Count,
sum(TiresOnVehicle) as "Number of wheels"
from
[dbo].[ParkedVehicles]

group by
TypeOfVehicle
order by
Count desc, "Number of wheels" desc, TypeOfVehicle;

select
count(id) as Count,
sum(TiresOnVehicle) as "Number of wheels"
from
[dbo].[ParkedVehicles]
