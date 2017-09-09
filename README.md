## Citi PC端

### HistoryEntry

- 保存历史记录；

- 保存当时存放的提交到后台的数据；

- | Name        | Type   | Comment |
  | ----------- | ------ | ------- |
  | name        | string | 保存记录的名称 |
  | date        | string | 当时的日期   |
  | probability | string | 当时计算的概率 |
  | comment     | string | 评价      |

### MyEntity

- 保存提交到后台的数据

- | 参数名                  | 必选   | 类型    | 说明          |
  | -------------------- | ---- | ----- | ----------- |
  | asset_standard       | 是    | float | 标准资产        |
  | national_debt        | 是    | float | 国债          |
  | enterprise_debt      | 是    | float | 企业债         |
  | trust_rate           | 是    | float | 收、受益权       |
  | trust_debt           | 是    | float | 信托贷款        |
  | debt_foundation      | 是    | float | 委托贷款        |
  | trust_debtRights     | 是    | float | 交易所委托债权     |
  | trust_stock          | 是    | float | 带回购条款的股权性融资 |
  | trust_transfer       | 是    | float | 信贷资产转让      |
  | receive              | 是    | float | 应收账款        |
  | self_debtRights      | 是    | float | 私募债权        |
  | bill                 | 是    | float | 票据类         |
  | credit               | 是    | float | 信用证         |
  | other                | 是    | float | 其他非标准化债权类投资 |
  | cash                 | 是    | float | 现金及银行存款     |
  | currency_market_tool | 是    | float | 货币市场工具      |
  | asset                | 是    | float | 权益类资产       |
  | cost_deposit         | 是    | float | 定期存款        |
  | cost_finance         | 是    | float | 理财产品        |

  ​