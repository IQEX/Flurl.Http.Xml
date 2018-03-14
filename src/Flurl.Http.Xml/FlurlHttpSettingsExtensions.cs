﻿using System;
using System.Text;
using System.Xml;
using Flurl.Http.Configuration;

namespace Flurl.Http.Xml
{
	/// <summary>
	/// FlurlHttpSettingsExtensions
	/// </summary>
	public static class FlurlHttpSettingsExtensions
	{
		private static XmlWriterSettings s_xmlWriterSettings = new XmlWriterSettings { Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: false), Indent = true, OmitXmlDeclaration = false };
		private static readonly Lazy<MicrosoftXmlSerializer> s_xmlSerializerInstance = new Lazy<MicrosoftXmlSerializer>(() => new MicrosoftXmlSerializer(s_xmlWriterSettings));

		/// <summary>
		/// XMLs the serializer.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public static MicrosoftXmlSerializer XmlSerializer(this FlurlHttpSettings settings)
		{
			return XmlSerializer(settings, s_xmlWriterSettings);
		}

		/// <summary>
		/// XMLs the serializer.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="xmlWriterSettings">The XML writer settings.</param>
		public static MicrosoftXmlSerializer XmlSerializer(this FlurlHttpSettings settings, XmlWriterSettings xmlWriterSettings)
		{
			s_xmlWriterSettings = xmlWriterSettings;
			return s_xmlSerializerInstance.Value;
		}
	}
}
