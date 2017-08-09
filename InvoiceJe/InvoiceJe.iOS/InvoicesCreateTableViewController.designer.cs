// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace InvoiceJe.iOS
{
    [Register ("InvoicesCreateTableViewController")]
    partial class InvoicesCreateTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Amount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField BillTo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ReferenceNumber { get; set; }

        [Action ("UIButton3265_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton3265_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Amount != null) {
                Amount.Dispose ();
                Amount = null;
            }

            if (BillTo != null) {
                BillTo.Dispose ();
                BillTo = null;
            }

            if (ReferenceNumber != null) {
                ReferenceNumber.Dispose ();
                ReferenceNumber = null;
            }
        }
    }
}