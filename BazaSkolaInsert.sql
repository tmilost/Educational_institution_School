
/*Skola*/
exec [dbo].[usp_Add_Table] 'Skola', IdSkole, 'bigint not null IDENTITY(1,1)'
exec [dbo].[usp_Add_PK] 'Skola', IdSkole
exec [dbo].[usp_Add_Field] 'Skola', Naziv, 'nvarchar(100) not null'
exec [dbo].[usp_Add_Field] 'Skola', Adresa, 'nvarchar(50) not null'
exec [dbo].[usp_Add_Field] 'Skola', Opstina, 'nvarchar(30) not null'
exec [dbo].[usp_Add_Field] 'Skola', PostanskiBroj, 'nvarchar(10) not null'
exec [dbo].[usp_Add_Field] 'Skola', MaticniBroj, 'nvarchar(8) not null'
exec [dbo].[usp_Add_Field] 'Skola', PIB, 'nvarchar(9) not null'
exec [dbo].[usp_Add_Field] 'Skola', BrojRacuna, 'nvarchar(30) not null'
exec [dbo].[usp_Add_Field] 'Skola', WebStranica, 'nvarchar(50) not null'
exec [dbo].[usp_Add_Field] 'Skola', Pecat, 'varchar(MAX) not null'
exec [dbo].[usp_Add_Field] 'Skola', Beleska, 'nvarchar(250) not null'


/*Osoba*/
exec [dbo].[usp_Add_Table] 'Osoba', IdOsobe, 'bigint not null IDENTITY(1,1)'
exec [dbo].[usp_Add_PK] 'Osoba', IdOsobe
exec [dbo].[usp_Add_Field] 'Osoba', Ime, 'nvarchar(30) not null'
exec [dbo].[usp_Add_Field] 'Osoba', Prezime, 'nvarchar(50) not null'
exec [dbo].[usp_Add_Field] 'Osoba', RadnoMesto, 'nvarchar(50) not null'
exec [dbo].[usp_Add_Field] 'Osoba', IdSkoleFK, 'bigint not null'


/*TipTelefona*/
exec [dbo].[usp_Add_Table] 'TipTelefona', IdTipaTelefona, 'bigint not null IDENTITY(1,1)'
exec [dbo].[usp_Add_PK] 'TipTelefona', IdTipaTelefona
exec [dbo].[usp_Add_Field] 'TipTelefona', Tip, 'nvarchar(15) not null'


/*TipMaila*/
exec [dbo].[usp_Add_Table] 'TipMaila', IdTipaMaila, 'bigint not null IDENTITY(1,1)'
exec [dbo].[usp_Add_PK] 'TipMaila', IdTipaMaila
exec [dbo].[usp_Add_Field] 'TipMaila', Tip, 'nvarchar(15) not null'


/*KontaktTelefon*/
exec [dbo].[usp_Add_Table] 'KontaktTelefon', IdTelefona, 'bigint not null IDENTITY(1,1)'
exec [dbo].[usp_Add_PK] 'KontaktTelefon', IdTelefona
exec [dbo].[usp_Add_Field] 'KontaktTelefon', BrojTelefona, 'nvarchar(20) not null'
exec [dbo].[usp_Add_Field] 'KontaktTelefon', Lokal, 'int not null'
exec [dbo].[usp_Add_Field] 'KontaktTelefon', IdTipaTelefonaFK, 'bigint not null'
exec [dbo].[usp_Add_Field] 'KontaktTelefon', IdOsobeFK, 'bigint not null'


/*MailListe*/
exec [dbo].[usp_Add_Table] 'MailListe', IdMaila, 'bigint not null IDENTITY(1,1)'
exec [dbo].[usp_Add_PK] 'MailListe', IdMaila
exec [dbo].[usp_Add_Field] 'MailListe', Adresa, 'nvarchar(50) not null'
exec [dbo].[usp_Add_Field] 'MailListe', IdTipaMailaFK, 'bigint not null'
exec [dbo].[usp_Add_Field] 'MailListe', IdOsobeFK, 'bigint not null'

/*Korisnik*/
exec [dbo].[usp_Add_Table] 'Korisnik', IdKorisnika, 'bigint not null IDENTITY(1,1)'
exec [dbo].[usp_Add_PK] 'Korisnik', IdKorisnika
exec [dbo].[usp_Add_Field] 'Korisnik', KorisnickoIme, 'nvarchar(30) not null'
exec [dbo].[usp_Add_Field] 'Korisnik', Lozinka, 'nvarchar(20) not null'
exec [dbo].[usp_Add_Field] 'Korisnik', PravoPristupa, 'int not null'

/*Spoljni kljucevi*/


exec [dbo].[usp_Add_FK] 'Osoba', IdSkoleFK, 'Skola', IdSkole

exec [dbo].[usp_Add_FK] 'KontaktTelefon', IdTipaTelefonaFK, 'TipTelefona', IdTipaTelefona
exec [dbo].[usp_Add_FK] 'KontaktTelefon', IdOsobeFK, 'Osoba', IdOsobe

exec [dbo].[usp_Add_FK] 'MailListe', IdTipaMailaFK, 'TipMaila', IdTipaMaila
exec [dbo].[usp_Add_FK] 'MailListe', IdOsobeFK, 'Osoba', IdOsobe