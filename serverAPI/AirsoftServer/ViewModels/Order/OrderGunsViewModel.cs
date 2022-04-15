﻿namespace ViewModels.Order
{
    using ViewModels.Images;

    public class OrderGunsViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Color { get; init; }

        public decimal Price { get; init; }

        public string Manufacturer { get; init; }

        public ImageViewModel Image { get; init; }
    }
}
