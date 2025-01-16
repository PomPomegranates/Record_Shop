# Record_Shop
The issue I'm having is twofold. Firstly, if I use the in-memory database like I did to start, 
then I have issues whenever I access my data for the second time. 
I have gone back and forth on adding the Album, albumID etc to the Song Classes and Artist 
classes, though with all the linking to Album, I can at least get it to run. 

However, the issue I have is that every time I try to access the data from the repository through my model class, on the *second* time through onwards, it replaces the song value and artist value on the album with null. Yesterday, through an unknown change in code, I managed to *not* get this problem if I repeated the GetAllAlbums, but *did* get a problem if I then tried to get a specific album through ID. 

I thought this might be an issue with in memory databases, and whether or not I have my keys on each class, but that hasn't seemed to make a difference and if anything, adding the AlbumId or Song lists on artists has just caused more pain.

I tried switching over to an SQL server, but now appear to be having issues trying to add the migration, because it's not successfully reading the Json I have in user secrets. It *definitely* doesn't run without that migration, however, further obscuring the issue. 

The few tests I managed to write under the time constraint seemed to show no issue, which is why I didn't catch this until much later in the day. 

I would really appreciate any advice or help on this, because as it is at the moment, I can't add any front end functionality because I can't get it working at all. 