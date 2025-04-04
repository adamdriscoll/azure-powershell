﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Services;
using Microsoft.WindowsAzure.Commands.Common.Sanitizer;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Providers
{
    internal class SanitizerJsonArrayProvider : SanitizerProviderBase
    {
        internal override SanitizerProviderType ProviderType => SanitizerProviderType.JsonArray;

        public SanitizerJsonArrayProvider(ISanitizerService service) : base(service) { }

        public override void SanitizeValue(object sanitizingObject, Stack<object> sanitizingStack, ISanitizerProviderResolver resolver, SanitizerProperty property, SanitizerTelemetry telemetry)
        {
            if (sanitizingObject is JArray arrJson)
            {
                for (var i = 0; i < arrJson.Count; i++)
                {
                    var jItem = arrJson[i];
                    if (jItem != null)
                    {
                        switch (jItem.Type)
                        {
                            case JTokenType.String:
                                if (Service.TrySanitizeData(jItem.Value<string>(), out var detections, out _))
                                {
                                    telemetry.SecretsDetected = true;
                                    var propertyPath = ResolvePropertyPath(property);
                                    if (!string.IsNullOrEmpty(propertyPath))
                                    {
                                        foreach (var detection in detections)
                                        {
                                            telemetry.DetectedProperties.AddPropertyInfo(propertyPath, detection.Moniker);
                                        }
                                    }
                                }
                                break;
                            case JTokenType.Array:
                            case JTokenType.Object:
                                var provider = resolver.ResolveProvider(jItem.GetType());
                                provider?.SanitizeValue(jItem, sanitizingStack, resolver, property, telemetry);
                                break;
                        }
                    }
                }
            }
        }
    }
}
