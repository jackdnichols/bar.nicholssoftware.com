//----------------------------------------------------------OCG Version: 3.7.0.0
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS_INC_PUBLIC_LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0

using System;

namespace OxyData
{
    /// <summary>
    /// Specifies how the key names of an entity may be returned
    /// </summary>
    public interface IVersionMarker
    {
        byte[] VersionMarker { get; }
    }
}
