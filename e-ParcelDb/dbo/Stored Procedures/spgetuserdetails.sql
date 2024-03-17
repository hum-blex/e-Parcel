Create proc spgetuserdetails
as
begin
select UserId,
		AddressLine1,
		AddressLine2
from UserAddress

end