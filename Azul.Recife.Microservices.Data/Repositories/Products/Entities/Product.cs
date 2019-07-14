using System.Collections.Generic;
using Azul.Framework.Data.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Azul.Recife.Microservices.Data.Repositories.Products.Entities
{
    /// <summary>
    /// Product class.
    /// </summary>
    /// <seealso>
    ///     <cref>Azul.Framework.Data.Entities.DataMappingBase{MongoDB.Bson.ObjectId}</cref>
    /// </seealso>
    public class Product : DataMappingBase<ObjectId>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public override ObjectId Id { get => base.Id; set => base.Id = value; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
    }

    /// <summary>
    /// Comment Class.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the comment text.
        /// </summary>
        /// <value>
        /// The comment text.
        /// </value>
        [JsonProperty("commentText")]
        public string CommentText{ get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        [JsonProperty("author")]
        public string Author { get; set; }
    }
}