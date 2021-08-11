/*!CK:2434163222!*//*1449608700,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["w4Cqp"]); }

__d('ReactComposerMediaAttachmentContainer.react',['Bootloader','ReactComposerAttachmentActions','ReactComposerAttachmentType','ReactComposerConfig','ReactComposerMediaAttachment.react','ReactComposerMediaStore','ReactComposerMediaUtils','ReactComposerPhotoCarouselStore','ReactComposerPhotoUploadActions','ReactComposerPhotoUploadStore','ReactComposerPhotoUploader','ReactComposerPrefillStore','ReactComposerPropsAndStoreBasedStateMixin','ReactComposerScrapedAttachmentStore','ReactComposerSlideshowActions','ReactComposerSlideshowStore','ReactComposerStatusUtils','ReactComposerTaggerActions','ReactComposerTaggerStore','ReactComposerTaggerType','ReactComposerVideoUploadActions','ReactComposerVideoUploader','ReactComposerVideoUploadStore','Arbiter','React','ReactDOM','PUWMethods','URLScraper','curry','invariant'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,ba,ca,da,ea,fa,ga,ha,ia,ja,ka){if(c.__markCompiled)c.__markCompiled();var la=fa.PropTypes,ma=fa.createClass({displayName:'ComposerMediaAttachmentContainer',_uploader:undefined,_videoUploader:undefined,_photoEditorSubscription:undefined,mixins:[t(m,o,q,u,w,z,da)],propTypes:{additionalTaggers:la.arrayOf(la.shape({button:la.element.isRequired,container:la.element.isRequired})),config:k.isRequired},statics:{beforeCalculateInitialState:function(na,oa){var pa=s.getAndEraseField(na,'photosData');pa&&p.prefillPhotos(na,pa);},calculateState:function(na,oa){return {createAlbumLink:m.getCreateAlbumLink(na),shouldShowCarouselURLInputArea:o.shouldShowURLEditArea(na),shouldShowCarouselPreview:u.getMarkup(na)!==null,isSlideshowSelected:w.isSlideshowSelected(na),selectedTagger:z.getSelectedTagger(na),uploads:q.getUploads(na),video:da.getVideo(na),videoProgressBar:m.getVideoProgressBar(na),videoProgressBarInstance:m.getVideoProgressBarInstance(na),videoUploader:m.getVideoUploader(na)};}},componentWillMount:function(){var na=this.props.config.attachmentsConfig[j.MEDIA];this._uploader=new r(this.context,na.photoLimit,{disableFaceRecognition:na.disableFaceboxTagger});this._photoEditorSubscription=ea.subscribe(['AttachmentsPhotoEditor/newImage'+this.context.composerID,'AttachmentsPhotoEditor/tagsUpdated'+this.context.composerID],ja(n.onImageEdited,this.context.composerID,this._uploader));},componentDidMount:function(){var na=this.props.config.attachmentsConfig[j.MEDIA];this._videoUploader=new ca({composerID:this.context.composerID,container:ga.findDOMNode(this.refs.videoContainer),progressBarInstance:this.state.videoProgressBarInstance,uploader:this.state.videoUploader,shouldShowOptimisticVideoPost:na.shouldShowOptimisticVideoPost,composerEntryPointRef:this.context.composerType});ba.setUploader(this.context.composerID,this._videoUploader);},componentWillUnmount:function(){this._videoUploader&&this._videoUploader.destroy();this._photoEditorSubscription&&this._photoEditorSubscription.unsubscribe();this._photoEditorSubscription=null;},componentWillUpdate:function(na,oa){oa=oa||{};if((this.state.uploads.size>0||!!this.state.video)&&oa.uploads.size===0&&!oa.video){i.selectAttachment(this.context.composerID,j.STATUS,true);v.hideSlideshowEditField(this.context.composerID);}},render:function(){return (fa.createElement('div',null,fa.createElement(l,babelHelpers._extends({},this.props,{createAlbumLink:this.state.createAlbumLink,isSlideshowSelected:this.state.isSlideshowSelected,shouldShowCarouselURLInputArea:this.state.shouldShowCarouselURLInputArea,shouldShowCarouselPreview:this.state.shouldShowCarouselPreview,onFilesSelected:this._onFilesSelected,onMentionsInputChange:this._onMentionsInputChange,onMentionsInputFocus:this._onMentionsInputFocus,onPasteRawText:this._onPasteRawText,postButtonModule:this.props.postButtonModule,uploads:this.state.uploads,video:this.state.video,videoProgressBar:this.state.videoProgressBar})),fa.createElement('div',{ref:'videoContainer'})));},_onFilesSelected:function(event,na){var oa=event.target,pa=this.props.config.attachmentsConfig[j.MEDIA];if(pa.useVideoUploadDialog){var qa=n.getFileNamesFromFileInput(oa),ra=n.hasVideos(qa),sa=n.hasAudioFiles(qa);if(oa.files&&oa.files.length===1)if(sa&&pa.canUploadAudio){h.loadModules(["ComposerXAudioUploadDialogController"],(function(ta){return (ta.showDialog({targetID:this.context.targetID,fileInput:na}));}).bind(this));return;}else if(ra){h.loadModules(["ComposerXVideoUploadDialogController"],(function(ta){return (ta.showDialog({targetID:this.context.targetID,fileInput:na,composerEntryPointRef:this.context.composerType,canShowOptimisticPost:pa.shouldShowOptimisticVideoPost,originalComposerID:this.context.composerID}));}).bind(this));return;}}!this._uploader?ka(0):undefined;n.uploadPhotosOrVideoFromTarget(this.context.composerID,event.target,this._uploader,this.props.config.targetData.targetSupportsMultiplePhotos);},_onMentionsInputFocus:function(){if(this.state.selectedTagger!==null&&this.state.selectedTagger!==aa.PEOPLE)y.selectTaggerWithoutAutofocus(this.context.composerID,aa.PEOPLE);},_onPasteRawText:function(na){var oa=this.props.config.attachmentsConfig[j.MEDIA],pa=o.shouldShowURLEditArea(this.context.composerID);if(!oa.carouselConfig||!pa)return;if(oa.carouselConfig.ComposerPhotoCarouselPlaceHolder)x.scrapeLink(this.context.composerID,this.context.targetID,na,this.context.composerType,this.context.actorID);},_onMentionsInputChange:function(na){var oa=this.props.config.attachmentsConfig[j.MEDIA],pa=o.shouldShowURLEditArea(this.context.composerID);if(!oa.carouselConfig||!pa)return;if(oa.carouselConfig.ComposerPhotoCarouselPlaceHolder){var qa=na.getCurrentContent().getPlainText();if(!ia.trigger(qa))x.scrapeLink(this.context.composerID,this.context.targetID,qa,this.context.composerType,this.context.actorID);}}});f.exports=ma;},null);