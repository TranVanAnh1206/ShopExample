/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

    // tích hợp ckFinder vào ckEditor
    config.filebrowserBrowseUrl = '/Assets/Admin/Libs/CKFinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Assets/Admin/Libs/CKFinder/ckfinder.html?type=Images';
    config.filebrowserUploadUrl = '/Assets/Admin/Libs/CKFinder/connector?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Assets/Admin/Libs/CKFinder/connector?command=QuickUpload&type=Images';
    config.filebrowserWindowWidth = '1000';
    config.filebrowserWindowHeight = '700';
};
