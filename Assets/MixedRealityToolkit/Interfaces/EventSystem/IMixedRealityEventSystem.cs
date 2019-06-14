﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Microsoft.MixedReality.Toolkit
{
    /// <summary>
    /// Interface used to implement an Event System that is compatible with the Mixed Reality Toolkit.
    /// </summary>
    public interface IMixedRealityEventSystem : IMixedRealityService
    {
        /// <summary>
        /// List of event listeners that are registered to this Event System.
        /// </summary>
        // Marking EventListeners as obsolete triggers a lot of warnings in MRTK code base.
        // This should be commented out once follow up task #4847 is complete.
        //[Obsolete("EventListeners is replaced by EventHandlersByType and will be removed in a future release.")]*/
        List<GameObject> EventListeners { get; }

        /// <summary>
        /// The main function for handling and forwarding all events to their intended recipients.
        /// </summary>
        /// <remarks>See: https://docs.unity3d.com/Manual/MessagingSystem.html </remarks>
        /// <typeparam name="T">Event Handler Interface Type</typeparam>
        /// <param name="eventData">Event Data</param>
        /// <param name="eventHandler">Event Handler delegate</param>
        void HandleEvent<T>(BaseEventData eventData, ExecuteEvents.EventFunction<T> eventHandler) where T : IEventSystemHandler;

        /// <summary>
        /// Registers a <see href="https://docs.unity3d.com/ScriptReference/GameObject.html">GameObject</see> to listen for events from this Event System.
        /// </summary>
        /// <param name="listener"><see href="https://docs.unity3d.com/ScriptReference/GameObject.html">GameObject</see> to add to <see cref="EventListeners"/>.</param>
        // Marking method as obsolete triggers a lot of warnings in MRTK code base.
        // This should be commented out once follow up task #4847 is complete.
        //[Obsolete("Register using a game object causes all components of this object to receive global events of all types. " +
        //    "Use RegisterHandler<> methods instead to avoid unexpected behavior.")]
        void Register(GameObject listener);

        /// <summary>
        /// Unregisters a <see href="https://docs.unity3d.com/ScriptReference/GameObject.html">GameObject</see> from listening for events from this Event System.
        /// </summary>
        /// <param name="listener"><see href="https://docs.unity3d.com/ScriptReference/GameObject.html">GameObject</see> to remove from <see cref="EventListeners"/>.</param>
        // Marking method as obsolete triggers a lot of warnings in MRTK code base.
        // This should be commented out once follow up task #4847 is complete
        //[Obsolete("Unregister using a game object will disable listening of global events for all components of this object. " +
        //    "Use UnregisterHandler<> methods instead to avoid unexpected behavior.")]
        void Unregister(GameObject listener);

        /// <summary>
        /// Registers the given handler as a global listener for all events handled via the T interface.
        /// T must be an interface type, not a class type, derived from IEventSystemHandler.
        /// </summary>
        /// <remarks>
        /// If you want to register a single C# object as global handler for several event handling interfaces,
        /// you must call this function for each interface type. E.g. 
        /// RegisterHandler<ISpeechEventHandler>(this);
        /// RegisterHandler<IPointerEventHandler>(this);
        /// </remarks>
        /// <param name="handler">Handler to add to <see cref="HandlerEventListeners"/>.</param>
        void RegisterHandler<T>(IEventSystemHandler handler) where T : IEventSystemHandler;

        /// <summary>
        /// Unregisters the given handler as a global listener for all events handled via the T interface.
        /// T must be an interface type, not a class type, derived from IEventSystemHandler.
        /// </summary>
        /// <remarks>
        /// If a single C# object listens to global input events for several event handling interfaces,
        /// you must call this function for each interface type. E.g. 
        /// UnregisterHandler<ISpeechEventHandler>(this);
        /// UnregisterHandler<IPointerEventHandler>(this);
        /// </remarks>
        /// <param name="handler">Handler to remove from <see cref="HandlerEventListeners"/>.</param>
        void UnregisterHandler<T>(IEventSystemHandler handler) where T : IEventSystemHandler;
    }
}
