# GitStats
## Show code status on your local Git repository
Currently, this shows a Brittles report. The Brittles report contains three sub-reports:

1. MostChanged - These are the files which change most often. Likely this indicates areas of fragility in the code. These are good areas for target refactoring, unit testing, and code coverage.
1. MostChanges
 1. Adds - The files with the most additions. Be wary of files which grow quickly. You might be putting too much logic in them.
 1. Deletes - The files with the most deletions. These are usually good changes and indicate good refactoring practices.

### Usage
GitStats.exe <path to local git repo> <commit count> [branch name]

### Show status for the last 200 commits on your master branch
```
GitStats.exe 'C:\projects\GitStats\' 200 master
```

### Show status for the last 200 commits on your current branch
```
GitStats.exe 'C:\projects\GitStats\' 200
```

### Example output
```
FileName	NumberOfTimesChanged	PercentTimesChanged
xxx\Web.config	15	30.0
xxx\BLL\Services\Orders\OrderDuplicationService.cs	15	30.0
xxx\DAO\OrderDAO.cs	11	22.00
xxx\Payment.aspx.cs	6	12.00
xxx\OrderLogistics.aspx	5	10.0
xxx\DAO\GiftCertificateDAO.cs	5	10.0
xxx\BLL\Services\Payments\GiftCertificate\GiftCertificate.cs	5	10.0
xxx\Services\Orders.asmx.cs	4	8.00
xxx\BLL\Services\Cart\CartValidationService.cs	4	8.00
xxx\BLL\Services\Fees\FeeService.cs	4	8.00
xxx\UserControls\OrderDetails\CartSummary\ConfirmOrderSummary.ascx	3	6.00
```
