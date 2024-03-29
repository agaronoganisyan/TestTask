using OffersLogic.OffersDataLogic;
using UniRx;

namespace OffersLogic
{
    public class OffersHandler : IOffersHandler
    {
        public ReactiveCollection<OfferData> Offers { get; }

        private OffersData _data;

        public OffersHandler(OffersData data)
        {
            _data = data;

            Offers = new ReactiveCollection<OfferData>();
            
            for (int i = 0; i < _data.Offers.Length; i++)
            {
                Offers.Add(_data.Offers[i]);
            }
        }

        public void Remove(OfferData offerData)
        {
            if (!Offers.Contains(offerData)) return;

            Offers.Remove(offerData);
        }
    }
}