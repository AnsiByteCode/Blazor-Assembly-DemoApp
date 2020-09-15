using Newtonsoft.Json;

namespace CashDeskDemoApp.Shared.Models
{
    /// <summary>
    /// YahooResponseData
    /// </summary>
    public class YahooResponseData
    {
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [JsonProperty("language")]
        public string Language { get; set; }
        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        [JsonProperty("region")]
        public string Region { get; set; }
        /// <summary>
        /// Gets or sets the type of the quote.
        /// </summary>
        /// <value>
        /// The type of the quote.
        /// </value>
        [JsonProperty("quoteType")]
        public string QuoteType { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="YahooResponseData"/> is triggerable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if triggerable; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("triggerable")]
        public bool Triggerable { get; set; }
        /// <summary>
        /// Gets or sets the name of the quote source.
        /// </summary>
        /// <value>
        /// The name of the quote source.
        /// </value>
        [JsonProperty("quoteSourceName")]
        public string QuoteSourceName { get; set; }
        /// <summary>
        /// Gets or sets the exchange data delayed by.
        /// </summary>
        /// <value>
        /// The exchange data delayed by.
        /// </value>
        [JsonProperty("exchangeDataDelayedBy")]
        public int ExchangeDataDelayedBy { get; set; }
        /// <summary>
        /// Gets or sets the market.
        /// </summary>
        /// <value>
        /// The market.
        /// </value>
        [JsonProperty("market")]
        public string Market { get; set; }
        /// <summary>
        /// Gets or sets the regular market change percent.
        /// </summary>
        /// <value>
        /// The regular market change percent.
        /// </value>
        [JsonProperty("regularMarketChangePercent")]
        public decimal RegularMarketChangePercent { get; set; }
        /// <summary>
        /// Gets or sets the regular market previous close.
        /// </summary>
        /// <value>
        /// The regular market previous close.
        /// </value>
        [JsonProperty("regularMarketPreviousClose")]
        public decimal RegularMarketPreviousClose { get; set; }
        /// <summary>
        /// Gets or sets the full name of the exchange.
        /// </summary>
        /// <value>
        /// The full name of the exchange.
        /// </value>
        [JsonProperty("fullExchangeName")]
        public string FullExchangeName { get; set; }
        /// <summary>
        /// Gets or sets the long name.
        /// </summary>
        /// <value>
        /// The long name.
        /// </value>
        [JsonProperty("longName")]
        public string LongName { get; set; }
        /// <summary>
        /// Gets or sets the price hint.
        /// </summary>
        /// <value>
        /// The price hint.
        /// </value>
        [JsonProperty("priceHint")]
        public decimal PriceHint { get; set; }
        /// <summary>
        /// Gets or sets the regular market price.
        /// </summary>
        /// <value>
        /// The regular market price.
        /// </value>
        [JsonProperty("regularMarketPrice")]
        public decimal RegularMarketPrice { get; set; }
        /// <summary>
        /// Gets or sets the regular market time.
        /// </summary>
        /// <value>
        /// The regular market time.
        /// </value>
        [JsonProperty("regularMarketTime")]
        public double RegularMarketTime { get; set; }
        /// <summary>
        /// Gets or sets the regular market change.
        /// </summary>
        /// <value>
        /// The regular market change.
        /// </value>
        [JsonProperty("regularMarketChange")]
        public decimal RegularMarketChange { get; set; }
        /// <summary>
        /// Gets or sets the state of the market.
        /// </summary>
        /// <value>
        /// The state of the market.
        /// </value>
        [JsonProperty("marketState")]
        public string MarketState { get; set; }
        /// <summary>
        /// Gets or sets the exchange.
        /// </summary>
        /// <value>
        /// The exchange.
        /// </value>
        [JsonProperty("exchange")]
        public string Exchange { get; set; }
        /// <summary>
        /// Gets or sets the source interval.
        /// </summary>
        /// <value>
        /// The source interval.
        /// </value>
        [JsonProperty("sourceInterval")]
        public decimal SourceInterval { get; set; }
        /// <summary>
        /// Gets or sets the name of the exchange timezone.
        /// </summary>
        /// <value>
        /// The name of the exchange timezone.
        /// </value>
        [JsonProperty("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }
        /// <summary>
        /// Gets or sets the short name of the exchange timezone.
        /// </summary>
        /// <value>
        /// The short name of the exchange timezone.
        /// </value>
        [JsonProperty("exchangeTimezoneShortName")]
        public string ExchangeTimezoneShortName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [esg populated].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [esg populated]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("esgPopulated")]
        public bool EsgPopulated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="YahooResponseData"/> is tradeable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if tradeable; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("tradeable")]
        public bool Tradeable { get; set; }
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
