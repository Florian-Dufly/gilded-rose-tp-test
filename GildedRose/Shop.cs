namespace GildedRose
{
    public class Shop
    {
        private List<Item> items = new List<Item>() {
            new Item { Name = "Sulfuras", SellIn = 4, Quality = 80 },
            new Item { Name = "Aged Brie", SellIn = 30, Quality = 25 },
            new Item { Name = "Backstage passes", SellIn = 20, Quality = 18 },
            new Item { Name = "Conjured", SellIn = 20, Quality = 40 }
        };

        // abstract class Item {
        //     abstract void Update();
        // }

        // abstract AgedBrie extends Item {
        //     void Update() {
        //         this.
        //     }
        // }

        public void Update(Item items){
            foreach(Item item in this.items){
                UpdateQuality(item);
                UpdateSellIn(item);
            }
        }


        limitQuality(Item item, int min, int max)
        {
            if (item.Quality < min)
                item.Quality = min
            if (item.Quality > max)
                item.Quality = max
        }


        public void UpdateQuality(Item item)
        {
            if (item.Name != "Sulfuras")
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        HandleAgedBrie(item);
                        break;

                    case "Backstage passes":
                        HandleBackstagePasses(item);
                        break;

                    case "Conjured":
                        HandleConjured(item);
                        break;

                    default:
                        HandleDefault(item);
                        break;
                }
                limitQuality(item, 0, 50);
            }
        }

        public void UpdateSellIn(Item item)
        {
            // Mise à jour de la valeur SellIn pour tous les articles (sauf "Sulfuras")
            if (item.Name != "Sulfuras")
            {
                item.SellIn--;
            }
        }

        private void HandleAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn <= 0)
                {
                    item.Quality++;
                }
            }
        }

        private void HandleBackstagePasses(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn <= 10)
                {
                    item.Quality++;
                }
                else if (item.SellIn <= 5)
                {
                    item.Quality += 2;
                }
                if (item.SellIn <= 0)
                {
                    item.Quality = 0; // La qualité tombe à 0 après le concert
                }
            }
        }

        private void HandleConjured(Item item)
        {
                item.Quality -= 2; // Les objets "Conjured" se dégradent deux fois plus vite
        }

        private void HandleDefault(Item item)
        {
            item.Quality--;
            if (item.SellIn <= 0)
                item.Quality--; // La qualité se dégrade deux fois plus vite après la date de péremption
        }


    }
}
