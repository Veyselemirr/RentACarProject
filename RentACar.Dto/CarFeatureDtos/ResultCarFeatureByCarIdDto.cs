﻿namespace RentACar.Dto.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int CarFeatureID { get; set; }
        public bool Available { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
    }
}
