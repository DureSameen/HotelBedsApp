﻿namespace com.hotelbeds.distribution.hotel_api_model.auto.model
{
    public class AuditData
    {
        public string processTime { get; set; }
        public string timestamp { get; set; }
        public string requestHost { get; set; }
        public string serverId { get; set; }
        public string environment { get; set; }
        public string release { get; set; }
        public string expiration { get; set; }
    }
}
