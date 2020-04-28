# Educational_institution_School
ASP.NET MVC + Bootstrap + SQL // This application is for ministry that will take care of the registration of the school and its employees

Look Documentation

# Opis razvijene aplikacije

Ova aplikacija je namenjena za obrazovnu ustanovu, tačnije za ministarstvo koje će voditi računa o registraciji škole i njenim zaposlenima. 

Aplikacija služi da olakša i pojednostavi proces registracije nove škole, kao i prijavu zaposlenih i uvid u podatke zaposlenih i registrovanih škola.

Ideja je da se prilikom popunjavanja podataka (registraciji) o školi ili zaposlenom osoblju izbegne što je moguće više grešaka i da se jednim klikom (potvrdom) završi kompletna registracija, čime bi znatno uštedelo na vremenu i smanjili troškovi. Takođe, moguće je nakon registracije izmeniti podatke u slučaju da je došlo do promene nekih podataka u međuvremenu, uz odobrenje administratora.

Prilikom pokretanja aplikacije, postoje tri vrste pristupa. Prvi je korisnik sa pravom pregleda, koji samo može da vidi podatke na formi i da ih odštampa. Drugi je korisnik sa pravom unosa, koji ima uvid u podatke, može da unosi podatke u formu, menja podatke i da ih štampa i treći je korisnik sa pravom administracije (admin), koji ima uvid u podatke, može da unosu podatke na formu, da menja podatke, štampa, može da izbriše podatke za određeni entitet u sistemu, određuje pravo pristupa novom korisniku aplikacije, resetuje (promeni) lozinku postojećem korisniku, može da menja pravo pristupa za određenog korisnika i da izbriše korisnika.

Za korisnika je omogućen unos podataka kao što su: naziv škole, adresa škole, opština, poštanski broj, matični broj škole, PIB, broj računa škole u platnom prometu, web stranicu škole, fotografiju pečata škole, listu kontakt osoba koja sadrži podatke kao što su: ime kontakt osobe, prezime, radno mesto, kontakt telefon (službeni, privatni ili mobilni), mail adresu (službena ili privatna) kontakt osobe, kao i lokal. Takođe, može se dodavati beleška po potrebi. Identifikacioni broj (ID broj) se ne dodaje, jer se on sam generiše (auto increment) za svaku sledeću školu. 
