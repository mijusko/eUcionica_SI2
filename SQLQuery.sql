-- Unos predmeta
INSERT INTO Predmet (NazivPredmeta) VALUES ('Matematika'), ('Fizika'), ('Biologija'), ('Istorija'), ('Geografija');

-- Unos oblasti
INSERT INTO Oblast (PredmetID, Name) VALUES 
(1, 'Aritmetika'), (1, 'Geometrija'),
(2, 'Mehanika'), (2, 'Optika'),
(3, 'Botanika'), (3, 'Zoologija'),
(4, 'Stari vek'), (4, 'Srednji vek'),
(5, 'Fizicka geografija'), (5, 'Socijalna geografija');

-- Unos pitanja
INSERT INTO Pitanje (PredmetID, OblastID, NivoTezine, PitanjeText, TacanOdgovor) VALUES
-- Matematika - Aritmetika
(1, 1, 'Lako', 'Koliko je 7 + 5?', '12'),
(1, 1, 'Lako', 'Koliko je 15 - 8?', '7'),
(1, 1, 'Srednje', 'Koliko je 12 × 8?', '96'),
(1, 1, 'Srednje', 'Koliko je 45 ÷ 9?', '5'),
(1, 1, 'Tesko', 'Koliki je rezultat izraza (3 + 5) × 2 - 4?', '12'),
(1, 1, 'Tesko', 'Koliki je zbir prvih pet prostih brojeva?', '28'),
-- Matematika - Geometrija
(1, 2, 'Lako', 'Koliko uglova ima trougao?', '3'),
(1, 2, 'Lako', 'Koji je obim kvadrata stranice 5 cm?', '20 cm'),
(1, 2, 'Srednje', 'Kolika je površina pravougaonika dimenzija 6 cm i 4 cm?', '24 cm²'),
(1, 2, 'Srednje', 'Ako je poluprečnik kruga 3 cm, kolika je njegova površina? (Koristi π = 3.14)', '28.26 cm²'),
(1, 2, 'Tesko', 'Kolika je površina trougla čije su stranice 6 cm, 8 cm i 10 cm?', '24 cm²'),
(1, 2, 'Tesko', 'Kolika je zapremina kocke čija je stranica 4 cm?', '64 cm³'),
-- Fizika - Mehanika
(2, 3, 'Lako', 'Šta je sila?', 'Sila je vektor koji predstavlja uzrok promene stanja kretanja ili oblika tela.'),
(2, 3, 'Lako', 'Šta je brzina?', 'Brzina je fizička veličina koja opisuje pređeni put u jedinici vremena.'),
(2, 3, 'Srednje', 'Kako se računa brzina kada su poznati pređeni put i vreme?', 'Brzina se računa kao pređeni put podeljen sa vremenom (v = s/t).'),
(2, 3, 'Srednje', 'Kako se računa težina tela ako je poznata masa?', 'Težina tela se računa kao proizvod mase i gravitacionog ubrzanja (G = m × g).'),
(2, 3, 'Tesko', 'Objasni zakon inercije.', 'Zakon inercije, ili prvi Njutnov zakon, kaže da svako telo ostaje u stanju mirovanja ili jednolikog pravolinijskog kretanja dok ga spoljašnja sila ne primora da to stanje promeni.'),
(2, 3, 'Tesko', 'Kako se računa kinetička energija tela?', 'Kinetička energija tela se računa kao polovina proizvoda mase i kvadrata brzine (E_k = 1/2 mv²).'),
-- Fizika - Optika
(2, 4, 'Lako', 'Šta je svetlosni zrak?', 'Svetlosni zrak je linija koja predstavlja putanju svetlosti.'),
(2, 4, 'Lako', 'Šta je ogledalo?', 'Ogledalo je površina koja reflektuje svetlost i omogućava formiranje slike objekata.'),
(2, 4, 'Srednje', 'Šta je lom svetlosti?', 'Lom svetlosti je promena pravca svetlosnog zraka kada prelazi iz jedne sredine u drugu zbog promene brzine svetlosti.'),
(2, 4, 'Srednje', 'Kako funkcioniše lupa?', 'Lupa je konveksno sočivo koje uvećava sliku predmeta tako što savija svetlosne zrake prema jednom fokalnom tačkom.'),
(2, 4, 'Tesko', 'Objasni razliku između konkavnog i konveksnog ogledala.', 'Konkavno ogledalo ima unutrašnju reflektivnu površinu i fokusira svetlost u jednu tačku, dok konveksno ogledalo ima spoljašnju reflektivnu površinu i razbacuje svetlost, dajući šire vidno polje.'),
(2, 4, 'Tesko', 'Kako se svetlost ponaša kada prelazi iz vazduha u vodu?', 'Kada svetlost prelazi iz vazduha u vodu, ona se usporava i savija prema normali, zbog većeg indeksa prelamanja vode u odnosu na vazduh.'),
-- Biologija - Botanika
(3, 5, 'Lako', 'Šta je fotosinteza?', 'Fotosinteza je proces kojim biljke koriste sunčevu energiju da pretvore ugljen-dioksid i vodu u glukozu i kiseonik.'),
(3, 5, 'Lako', 'Koja je glavna funkcija korena biljke?', 'Glavna funkcija korena je apsorpcija vode i hranljivih materija iz tla, kao i sidrenje biljke.'),
(3, 5, 'Srednje', 'Koji su osnovni delovi cveta?', 'Osnovni delovi cveta su čašica, krunica, prašnici i tučak.'),
(3, 5, 'Srednje', 'Koji pigment daje listovima zelenu boju?', 'Hlorofil je pigment koji daje listovima zelenu boju.'),
(3, 5, 'Tesko', 'Objasni proces transpiracije kod biljaka.', 'Transpiracija je proces isparavanja vode kroz otvore (stome) na listovima biljaka, što pomaže u regulaciji temperature i transportu hranljivih materija.'),
(3, 5, 'Tesko', 'Koja je razlika između jednogodišnjih i višegodišnjih biljaka?', 'Jednogodišnje biljke završavaju svoj životni ciklus unutar jedne godine, dok višegodišnje biljke žive više godina i obnavljaju se svake sezone.'),
-- Biologija - Zoologija
(3, 6, 'Lako', 'Šta su kičmenjaci?', 'Kičmenjaci su životinje koje imaju kičmeni stub.'),
(3, 6, 'Lako', 'Koliko nogu ima pauk?', 'Pauk ima osam nogu.'),
(3, 6, 'Srednje', 'Koje su glavne karakteristike sisara?', 'Glavne karakteristike sisara su prisustvo dlake ili krzna i proizvodnja mleka za ishranu mladunaca putem mlečnih žlezda.'),
(3, 6, 'Srednje', 'Koja je funkcija peraja kod riba?', 'Peraja pomažu ribama u kretanju, stabilizaciji i upravljanju tokom plivanja.'),
(3, 6, 'Tesko', 'Objasni pojam adaptacije i daj primer.', 'Adaptacija je evolutivni proces kroz koji organizmi postaju bolje prilagođeni svom okruženju. Primer je kamuflaža kod polarnih medveda koji imaju belo krzno koje im pomaže da se uklope u snežno okruženje.'),
(3, 6, 'Tesko', 'Kako ptice migriraju na velike udaljenosti?', 'Ptice migriraju na velike udaljenosti koristeći se navigacijom putem sunčeve svetlosti, zvezda, magnetskog polja Zemlje i drugih orijentira.'),
-- Istorija - Stari vek
(4, 7, 'Lako', 'Ko je bio Aleksandar Veliki?', 'Aleksandar Veliki je bio kralj Makedonije koji je osvojio jedno od najvećih carstava u istoriji.'),
(4, 7, 'Lako', 'Koji je najpoznatiji grad-država u staroj Grčkoj?', 'Atina'),
(4, 7, 'Srednje', 'Koje su bile glavne karakteristike rimske vojske?', 'Rimska vojska je bila poznata po svojoj disciplini, organizaciji i inovativnoj vojnoj tehnologiji.'),
(4, 7, 'Srednje', 'Ko je bio prvi car Rimskog carstva?', 'Avgust Cezar'),
(4, 7, 'Tesko', 'Objasni značaj Punske ratove za Rimsko carstvo.', 'Punski ratovi su bili serija sukoba između Rima i Kartagine koji su rezultirali uništenjem Kartagine i uspostavljanjem Rima kao dominantne sile u zapadnom Mediteranu.'),
(4, 7, 'Tesko', 'Ko je bio Homer i koje su njegove poznate epopeje?', 'Homer je bio drevni grčki pesnik, poznat po epovima "Ilijada" i "Odiseja".'),
-- Istorija - Srednji vek
(4, 8, 'Lako', 'Šta je bio feudalizam?', 'Feudalizam je bio društveno-ekonomski sistem u srednjem veku koji se temeljio na zemljišnom vlasništvu i obavezama između gospodara i vazala.'),
(4, 8, 'Lako', 'Ko je bio Karlo Veliki?', 'Karlo Veliki je bio kralj Franka i prvi car Svetog Rimskog Carstva.'),
(4, 8, 'Srednje', 'Šta je bila Crna smrt?', 'Crna smrt je naziv za veliku epidemiju kuge koja je poharala Evropu u 14. veku.'),
(4, 8, 'Srednje', 'Koja je bila uloga viteza u srednjem veku?', 'Vitezovi su bili ratnici na konjima, često u službi feudalnih gospodara, poznati po hrabrosti i borbenim veštinama.'),
(4, 8, 'Tesko', 'Objasni značaj krstaških ratova.', 'Krstaški ratovi su bili vojni pohodi koje su organizovali hrišćani Zapadne Evrope sa ciljem osvajanja Svete zemlje od muslimanske vlasti. Imali su veliki uticaj na trgovinu, kulturu i odnose između Istoka i Zapada.'),
(4, 8, 'Tesko', 'Koji je bio značaj Magna Carte?', 'Magna Carta je bio dokument potpisan 1215. godine u Engleskoj, koji je ograničavao moć kralja i postavio temelje za ustavni zakon.'),
-- Geografija - Fizicka geografija
(5, 9, 'Lako', 'Šta je kontinent?', 'Kontinent je velika kopnena masa na Zemlji.'),
(5, 9, 'Lako', 'Koji je najveći okean na svetu?', 'Pacifički okean'),
(5, 9, 'Srednje', 'Šta je vulkan?', 'Vulkan je otvor u Zemljinoj kori kroz koji magma, pepeo i gasovi izlaze na površinu.'),
(5, 9, 'Srednje', 'Koje su glavne vrste reljefa?', 'Glavne vrste reljefa su planine, doline, visoravni i ravnice.'),
(5, 9, 'Tesko', 'Kako se formiraju tektonske ploče?', 'Tektonske ploče su velike delove Zemljine kore koji se kreću po površini Zemlje zbog konvekcije u mantlu.'),
(5, 9, 'Tesko', 'Objasni ciklus vode u prirodi.', 'Ciklus vode je proces kretanja vode na Zemlji, uključujući isparavanje, kondenzaciju, padavine i infiltraciju.'),
-- Geografija - Socijalna geografija
(5, 10, 'Lako', 'Šta je populacija?', 'Populacija je ukupan broj ljudi koji žive na nekom području.'),
(5, 10, 'Lako', 'Koji je glavni grad Francuske?', 'Pariz'),
(5, 10, 'Srednje', 'Šta je urbanizacija?', 'Urbanizacija je proces povećanja broja stanovnika koji žive u urbanim područjima.'),
(5, 10, 'Srednje', 'Šta je migracija?', 'Migracija je kretanje ljudi sa jednog mesta na drugo, često u potrazi za boljim životnim uslovima.'),
(5, 10, 'Tesko', 'Objasni razliku između razvijenih i nerazvijenih zemalja.', 'Razvijene zemlje imaju visok nivo industrijalizacije, bogatstva i standarda života, dok nerazvijene zemlje imaju nizak nivo tih faktora i često se suočavaju sa siromaštvom.'),
(5, 10, 'Tesko', 'Kako globalizacija utiče na lokalne kulture?', 'Globalizacija može dovesti do homogenizacije kultura, gde se lokalne tradicije i običaji zamenjuju globalnim uticajima, ali može i omogućiti širenje lokalnih kultura širom sveta.'); 

