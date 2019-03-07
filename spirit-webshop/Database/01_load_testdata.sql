SET IDENTITY_INSERT product ON;

INSERT INTO product (id, name, description, visibility, price, price_currency, stock,
                     order_quantity)
VALUES (1, 'KILKENNY Beer 330 ml / 4.3 % Irland',
        'Kilkenny Irish Beer ist ein obergäriges, rotes irisches Ale. In Irland läuft es unter dem Namen Smithwicks, was auch der Name der alten Brauerei in der Stadt Kilkenny ist. Die Brauerei Smithwicks ist seit Jahrzehnten Garant der Bewahrung des irischen roten Ale und Kilkenny Irish Beer wird so auch von vielen Geniessern als bester Vertreter seines Stands bezeichnet.',
        'ACTIVE', 3.90, 'CHF', 40, 0);
INSERT INTO product (id, name, description, visibility, price, price_currency, stock,
                     order_quantity)
VALUES (2, 'GUINNESS Draught Bier Glasflsche 330 ml / 4.2 % Irland',
        'Das irische Kultbier schmeckt vollmundig nach geröstetem Malz mit einem Hauch von Lakritze und Kaffee.',
        'HIDDEN', 4.50, 'CHF', 40, 0);
INSERT INTO product (id, name, description, visibility, price, price_currency, stock,
                     order_quantity)
VALUES (3, 'Baarer GOLDMANDLI Zuger Spezial Hell 330 ml / 5.2% Schweiz',
        'Dieses Bier strahlt einem strohgelb entgegen, und genau so fröhlich ist sein Duft, fein und unaufdringlich. Der Antrunk ist eine Mischung aus rosigem, fruchtigem Bonbongeschmack. Es entwickelt im Mund eine schöne Perlage und eine ausgewogene Bittere.',
        'ACTIVE', 3.50, 'CHF', 40, 0);
SET IDENTITY_INSERT product OFF;

SET IDENTITY_INSERT category ON;
INSERT INTO [ti5-spirit-db].[dbo].[category] (id, [name]) VALUES (1, 'Bier Hell')
INSERT INTO [ti5-spirit-db].[dbo].[category] (id, [name]) VALUES (2, 'Bier Dunkel')
SET IDENTITY_INSERT category OFF;


INSERT INTO [ti5-spirit-db].[dbo].[product_category] ([fk_product], [fk_category]) VALUES (3, 1)
INSERT INTO [ti5-spirit-db].[dbo].[product_category] ([fk_product], [fk_category]) VALUES (2, 2)
INSERT INTO [ti5-spirit-db].[dbo].[product_category] ([fk_product], [fk_category]) VALUES (1, 2)


