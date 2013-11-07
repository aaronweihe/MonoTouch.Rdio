using System;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.Rdio {

	[BaseType (typeof (NSObject), Name = "RDAPIRequestDelegate")]
	[Model]
	[Protocol]
	public partial interface RDAPIRequestDelegateHandlers {

		[Export ("rdioRequest:didLoadData:")]
		void DidLoadData (RDAPIRequest request, NSObject data);

		[Export ("rdioRequest:didFailWithError:")]
		void DidFailWithError (RDAPIRequest request, NSError error);
	}

	[BaseType (typeof (NSObject), Name = "RDAPIRequestDelegate")]
	public partial interface RDAPIRequestDelegate : RDAPIRequestDelegateHandlers {

		[Static, Export ("delegateToTarget:loadedAction:failedAction:")]
		NSObject DelegateToTarget (NSObject target, Selector load, Selector fail);

		[Export ("initWithTarget:action:")]
		IntPtr Constructor (NSObject target, Selector action);

		[Export ("initWithTarget:loadedAction:failedAction:")]
		IntPtr Constructor (NSObject target, Selector load, Selector fail);

		[Export ("userInfo", ArgumentSemantic.Retain)] [NullAllowed]
		NSObject UserInfo { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "RDAPIRequest")]
	public partial interface RDAPIRequest {

		[Export ("cancel")]
		void Cancel ();

		[Export ("parameters")]
		NSDictionary Parameters { get; }
	}

	[BaseType (typeof (NSObject), Name = "RDPlayerDelegate")]
	[Model]
	[Protocol]
	public partial interface RDPlayerDelegate {

		[Export ("rdioIsPlayingElsewhere")]
		bool RdioIsPlayingElsewhere();

		[Export ("rdioPlayerChangedFromState:toState:")]
		void ToState (RDPlayerState oldState, RDPlayerState newState);

		[Export ("rdioPlayerQueueDidChange")]
		void RdioPlayerQueueDidChange ();

		[Export ("rdioPlayerCouldNotStreamTrack:")]
		bool RdioCouldNotStreamTrack(string trackKey);
	}

	[BaseType (typeof (NSObject), Name = "RDPlayer")]
	public partial interface RDPlayer {

		[Export ("playSource:")]
		void PlaySource (string sourceKey);

		[Export ("playSources:")]
		void PlaySources (string [] sourceKeys);

		[Export ("next")]
		void Next ();

		[Export ("previous")]
		void Previous ();

		[Export ("skipToIndex:")]
		bool SkipToIndex (uint index);

		[Export ("play")]
		void Play ();

		[Export ("playAndRestart:")]
		void PlayAndRestart (bool shouldRestart);

		[Export ("togglePause")]
		void TogglePause ();

		[Export ("stop")]
		void Stop ();

		[Export ("seekToPosition:")]
		void SeekToPosition (double positionInSeconds);

		[Export ("queueSource:")]
		void QueueSource (string sourceKey);

		[Export ("queueSources:")]
		void QueueSources (string [] sourceKeys);

			[Export ("updateQueue:withCurrentTrackIndex:")]
			bool UpdateQueue (string[] sourceKeys, int index);

			[Export ("resetQueue")]
			void ResetQueue ();

			[Export ("state")]
			RDPlayerState State { get; }

			[Export ("position")]
			double Position { get; }

			[Export ("duration")]
			double Duration { get; }

			[Export ("currentTrack")]
			string CurrentTrack { get; }

			[Export ("currentTrackIndex")]
			int CurrentTrackIndex { get; }

			[Export ("trackKeys")]
			NSObject [] TrackKeys { get; }

			[Wrap ("WeakDelegate")][NullAllowed]
			RDPlayerDelegate Delegate{get;set;}

			[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
			NSObject WeakDelegate { get; set; }
			}

			[BaseType (typeof (NSObject))]
			public partial interface Rdio {

				[Export ("initWithConsumerKey:andSecret:delegate:")]
				IntPtr Constructor (string key, string secret, [NullAllowed] RdioDelegate aDelegate);

				[Export ("authorizeFromController:")]
				void AuthorizeFromController (UIViewController currentController);

				[Export ("authorizeUsingAccessToken:")]
				void AuthorizeUsingAccessToken (string accessToken);

				[Export ("authorizeUsingAccessToken:fromController:")]
				void AuthorizeUsingAccessToken (string accessToken, UIViewController currentController);

				[Export ("logout")]
				void Logout ();

				[Export ("callAPIMethod:withParameters:delegate:")]
				RDAPIRequest CallAPIMethod (string method, NSDictionary parameters, RDAPIRequestDelegate aDelegate);

				[Wrap("WeakDelegate")][NullAllowed]
				RdioDelegate Delegate{get;set;}

				[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
				NSObject WeakDelegate { get; set; }

				[Export ("user")]
				NSDictionary User { get; }

				[Export ("player")]
				RDPlayer Player { get; }
			}

			[BaseType (typeof (NSObject))]
			[Model]
			[Protocol]
			public partial interface RdioDelegate {

				[Export ("rdioDidAuthorizeUser:withAccessToken:")]
				void WithAccessToken (NSDictionary user, string accessToken);

				[Export ("rdioAuthorizationFailed:")]
				void AuthorizationFailed (string error);

				[Export ("rdioAuthorizationCancelled")]
				void RdioAuthorizationCancelled ();

				[Export ("rdioDidLogout")]
				void RdioDidLogout ();
	}
}
