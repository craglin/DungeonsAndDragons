using System;
using System.Collections.Generic;
using System.Xml;

namespace DungeonsAndDragons
{
    public static class XMLConverter
    {
        public static string Filepath { get; }

        static XMLConverter()
        {
            Filepath = @"..\..\..\..\Resources\";
        }

        public static void ExportRollHistory()
        {
            // Establish XML format settings
            XmlWriterSettings settings = new()
            {
                Indent = true,
                IndentChars = "  "
            };

            // Use settings file to write XML document
            using XmlWriter writer = XmlWriter.Create(Filepath + "RollHistory.xml", settings);
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("RollHistory");

                foreach (KeyValuePair<int, Tuple<int?, DateTime, RollType, DiceType, object, List<int>>> roll in DiceRoller.RollHistory)
                {
                    writer.WriteStartElement("RollTuple");
                    writer.WriteAttributeString("ID", roll.Key.ToString());
                    writer.WriteElementString("CupOwner", roll.Value.Item1.ToString());
                    writer.WriteElementString("DateTime", roll.Value.Item2.ToString());
                    writer.WriteElementString("RollType", roll.Value.Item3.ToString());
                    writer.WriteElementString("DiceType", roll.Value.Item4.ToString());
                    writer.WriteElementString("Result", roll.Value.Item5.ToString());
                    writer.WriteStartElement("Rolls");
                    foreach (int rollValue in roll.Value.Item6)
                        writer.WriteElementString("Roll", rollValue.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static void ExportTreasure()
        {

        }

        public static void ExportCast()
        {

        }

        public static void ExportLibrary()
        {

        }

        public static void ExportMint()
        {

        }

        public static void ExportVault()
        {

        }

        public static void ExportArmory()
        {

        }

        /// <summary>
        /// Reads the contents of an XML file and assigns to the RollHistory.
        /// </summary>
        private static void ImportRollTable()
        {
            using XmlReader reader = XmlReader.Create(Filepath + "RollHistory.xml");
            while (reader.Read())
                if (reader.IsStartElement())
                    switch (reader.Name)
                    {
                        // Overall game settings
                        case "GameSettings":
                            break;
                        case "UniverseSize":
                            //UniverseSize = reader.ReadElementContentAsInt();
                            break;
                        case "MSPerFrame":
                            //MSPerFrame = reader.ReadElementContentAsInt();
                            break;
                        case "FramesPerShot":
                            //ShotCooldown = reader.ReadElementContentAsInt();
                            break;
                        case "RespawnRate":
                            //TankRespawnRate = reader.ReadElementContentAsInt();
                            break;
                        case "Wall":
                            while (reader.Name != "x")
                                reader.Read();
                            int x1 = reader.ReadElementContentAsInt();
                            int y1 = reader.ReadElementContentAsInt();

                            while (reader.Name != "x")
                                reader.Read();
                            int x2 = reader.ReadElementContentAsInt();
                            int y2 = reader.ReadElementContentAsInt();

                            // Create wall based on points
                            //walls.Add(new Wall(new Vector2D(x1, y1), new Vector2D(x2, y2)));
                            break;
                        default:
                            break;
                    }
        }
    }
}
