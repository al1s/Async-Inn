select * from AsyncInn.dbo.Amenities;

select * from AsyncInn.dbo.Hotels;

select * from AsyncInn.dbo.HotelRooms;

select * from AsyncInn.dbo.Rooms;

select * from AsyncInn.dbo.RoomAmenities;

select * from AsyncInn.dbo.Layouts;

SELECT TOP(1) [h].[HotelId], [h].[RoomNumber], 
[h].[PetFriendly], [h].[Rate], [h].[RoomId], [h.Room].[RoomId], 
[h.Room].[LayoutId], [h.Room].[Name], [h.Hotel].[HotelId], 
[h.Hotel].[Address], [h.Hotel].[Name], [h.Hotel].[Phone]
FROM AsyncInn.dbo.HotelRooms AS [h]
INNER JOIN AsyncInn.dbo.[Rooms] AS [h.Room] ON [h].[RoomId] = [h.Room].[RoomId]
INNER JOIN AsyncInn.dbo.[Hotels] AS [h.Hotel] ON [h].[HotelId] = [h.Hotel].[HotelId]
WHERE ([h].[HotelId] = 1) AND ([h].[RoomId] = 324)

select * from
AsyncInn.dbo.HotelRooms AS [h]
where ([h].[HotelId] = 1) AND ([h].[RoomId] = 324)

insert into AsyncInn.dbo.RoomAmenities (amenityId, roomid) values (1,1)
insert into AsyncInn.dbo.RoomAmenities (amenityId, roomid) values (2,1)


truncate table AsyncInn.dbo.HotelRooms;
truncate table AsyncInn.dbo.RoomAmenities;
delete from AsyncInn.dbo.Amenities;
delete from AsyncInn.dbo.Hotels;
delete from AsyncInn.dbo.Rooms;
delete from AsyncInn.dbo.Layouts;