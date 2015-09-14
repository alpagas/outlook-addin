using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OAFramework;

namespace OAGUI.DataControl
{
    public class LargeAmountDataContainer : GenericLargeDataContainer<IDataUnitAmount>
    {

    }

    public class LargeLinkDataContainer : GenericLargeDataContainer<IDataUnitLink>
    {

    }

    public class LargeLabelDataContainer : GenericLargeDataContainer<IDataUnitLabel>
    {

    }

    public class LargeTextDataContainer : GenericLargeDataContainer<IDataUnitText>
    {
        
    }

    public class LargeDateDataContainer : GenericLargeDataContainer<IDataUnitDate>
    {

    }

    public class LargeCheckDataContainer : GenericLargeDataContainer<IDataUnitCheck>
    {

    }

    public class LargeComboDataContainer : GenericLargeDataContainer<IDataUnitCombo>
    {

    }

    public class SmallComboDataContainer : GenericSmallDataContainer<IDataUnitCombo>
    {

    }

    public class SmallNumberDataContainer : GenericSmallDataContainer<IDataUnitNumber>
    {

    }

    public class SmallTextDataContainer : GenericSmallDataContainer<IDataUnitText>
    {

    }

    public class SmallDateDataContainer : GenericSmallDataContainer<IDataUnitDate>
    {

    }

}
